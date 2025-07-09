using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Godot;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.Providers;

public class HyprlandEventProvider : IEventProvider
{
    // Runtime from the official Hyprland IPC spec:
    // $XDG_RUNTIME_DIR/hypr/$HYPRLAND_INSTANCE_SIGNATURE/.socket2.sock
    private static string SocketPath => GetSocketPath();

    private readonly Dictionary<string, ConstructorInfo> _constructors;
    private CancellationTokenSource _cts;
    private Task _readerTask;

    public event EventHandler<ISystemEvent> OnEvent;

    public HyprlandEventProvider()
    {
        _constructors = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && typeof(ISystemEvent).IsAssignableFrom(t))
            .Select(t => (attribute: t.GetCustomAttribute<HyprlandEventAttribute>(), type: t))
            .Where(x => x.attribute != null)
            .ToDictionary(
                x => x.attribute.EventName,
                x => x.type.GetConstructors().First()
            );
    }

    public void Start()
    {
        if (_readerTask is { IsCompleted: false })
        {
            GD.Print("HyprlandEventProvider: Reader task is already running.");
            return;
        }

        _cts = new CancellationTokenSource();
        _readerTask = Task.Run(() => ReadLoop(_cts.Token), _cts.Token);
    }

    public void Stop()
    {
        _cts?.Cancel();
        _readerTask = null;
        _cts = null;
    }

    private async Task ReadLoop(CancellationToken ct)
    {
        try
        {
            GD.Print($"HyprlandEventProvider: Starting read loop, socket path: {SocketPath}");

            GD.Print("Cancellation token registered: " + ct.IsCancellationRequested);

            // Wait until the socket file appears
            while (!ct.IsCancellationRequested && !File.Exists(SocketPath))
                await Task.Delay(500, ct);
            if (ct.IsCancellationRequested) return;

            using var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
            await socket.ConnectAsync(new UnixDomainSocketEndPoint(SocketPath), ct);
            using var reader = new StreamReader(new NetworkStream(socket), Encoding.UTF8);

            while (!ct.IsCancellationRequested)
            {
                string line;
                try
                {
                    line = await reader.ReadLineAsync(ct).ConfigureAwait(false);
                }
                catch
                {
                    break;
                }

                if (string.IsNullOrEmpty(line)) continue;

                GD.Print($"HyprlandEventProvider: Received line: {line}");

                // Format: "EVENTNAME>>arg1,arg2,..."
                var parts = line.Split([">>"], 2, StringSplitOptions.None);
                if (parts.Length != 2) continue;

                var name = parts[0].Trim();
                if (!_constructors.TryGetValue(name, out var ctor)) continue;

                var rawArgs = parts[1].Split(',', StringSplitOptions.None);
                var parameters = ctor.GetParameters();
                var args = new object[parameters.Length];

                for (var i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    if (param.ParameterType.IsArray)
                    {
                        var slice = rawArgs.Skip(i).ToArray();
                        var elemType = param.ParameterType.GetElementType();
                        var arr = Array.CreateInstance(elemType!, slice.Length);
                        for (var j = 0; j < slice.Length; j++)
                            arr.SetValue(ConvertArg(slice[j], elemType), j);
                        args[i] = arr;
                        break;
                    }

                    args[i] = i < rawArgs.Length
                        ? ConvertArg(rawArgs[i], param.ParameterType)
                        : (param.HasDefaultValue ? param.DefaultValue : GetDefault(param.ParameterType));
                }

                var evt = (ISystemEvent)ctor.Invoke(args);
                OnEvent?.Invoke(this, evt);
            }
        }
        catch (Exception e)
        {
            GD.PushWarning("HyprlandEventProvider: Error in ReadLoop: " + e.Message);
            throw;
        }
    }

    private static string GetSocketPath()
    {
        var runtimeDir = OS.GetEnvironment("XDG_RUNTIME_DIR");
        if (string.IsNullOrEmpty(runtimeDir))
            throw new InvalidOperationException("XDG_RUNTIME_DIR is not set.");

        var signature = OS.GetEnvironment("HYPRLAND_INSTANCE_SIGNATURE");
        if (string.IsNullOrEmpty(signature))
            throw new InvalidOperationException("HYPRLAND_INSTANCE_SIGNATURE is not set.");

        // hypr’s standard socket2 location
        return Path.Combine(runtimeDir, "hypr", signature, ".socket2.sock");
    }

    private static object ConvertArg(string raw, Type targetType)
    {
        if (targetType == typeof(string))
            return raw;

        if (targetType == typeof(bool) && (raw == "1" || raw.Equals("true", StringComparison.OrdinalIgnoreCase)))
            return true;

        return targetType == typeof(bool) ? false : Convert.ChangeType(raw, targetType);
    }

    private static object GetDefault(Type t) => t.IsValueType ? Activator.CreateInstance(t) : null;
}