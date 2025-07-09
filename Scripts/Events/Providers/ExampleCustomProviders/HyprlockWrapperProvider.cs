using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Godot;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;
using SuperWallpaper.Scripts.Events.EventTypes.ExampleCustomEvents;

namespace SuperWallpaper.Scripts.Events.Providers.ExampleCustomProviders;

public class HyprlockWrapperProvider : IEventProvider
{
    private readonly string _stateFilePath;
    private FileSystemWatcher _fileWatcher;
    private CancellationTokenSource _cancellationTokenSource;
    private bool? _lastKnownState;

    public event EventHandler<ISystemEvent> OnEvent;

    public HyprlockWrapperProvider()
    {
        var homeDir = OS.GetEnvironment("HOME");
        _stateFilePath = Path.Combine(homeDir, ".cache", "hyprlock_state");
    }

    public void Start()
    {
        if (_fileWatcher != null)
        {
            GD.PrintRich("[color=yellow]HyprlockWrapperProvider: Already started[/color]");
            return;
        }

        _cancellationTokenSource = new CancellationTokenSource();
        
        try
        {
            var cacheDir = Path.GetDirectoryName(_stateFilePath);

            if (!Directory.Exists(cacheDir) && cacheDir != null) 
                Directory.CreateDirectory(cacheDir);

            // Read initial state
            ReadAndDispatchState();

            // Set up file watcher
            _fileWatcher = new FileSystemWatcher(cacheDir!, Path.GetFileName(_stateFilePath) ?? string.Empty)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Size,
                EnableRaisingEvents = true
            };

            _fileWatcher.Changed += OnFileChanged;
            _fileWatcher.Created += OnFileChanged;
            _fileWatcher.Error += OnWatcherError;

            GD.PrintRich($"[color=green]HyprlockWrapperProvider: Started monitoring {_stateFilePath}[/color]");
        }
        catch (Exception ex)
        {
            GD.PrintErr($"HyprlockWrapperProvider: Failed to start - {ex.Message}");
            Stop();
            throw;
        }
    }

    public void Stop()
    {
        _cancellationTokenSource?.Cancel();
        
        if (_fileWatcher != null)
        {
            _fileWatcher.EnableRaisingEvents = false;
            _fileWatcher.Changed -= OnFileChanged;
            _fileWatcher.Created -= OnFileChanged;
            _fileWatcher.Error -= OnWatcherError;
            _fileWatcher.Dispose();
            _fileWatcher = null;
        }

        _cancellationTokenSource?.Dispose();
        _cancellationTokenSource = null;
        _lastKnownState = null;

        GD.PrintRich("[color=orange]HyprlockWrapperProvider: Stopped[/color]");
    }

    private void OnFileChanged(object sender, FileSystemEventArgs e)
    {
        if (_cancellationTokenSource?.Token.IsCancellationRequested == true)
            return;

        // Debounce multiple rapid file changes
        if (_cancellationTokenSource != null)
            Task.Delay(50, _cancellationTokenSource.Token)
                .ContinueWith(_ => ReadAndDispatchState(), _cancellationTokenSource.Token);
    }

    private void OnWatcherError(object sender, ErrorEventArgs e)
    {
        GD.PrintErr($"HyprlockWrapperProvider: FileWatcher error - {e.GetException().Message}");
        
        // Attempt to restart the watcher
        Stop();
        Task.Delay(1000).ContinueWith(_ => Start());
    }

    private void ReadAndDispatchState()
    {
        try
        {
            if (!File.Exists(_stateFilePath))
            {
                // If file doesn't exist, assume unlocked
                DispatchStateChange(false);
                return;
            }

            var content = File.ReadAllText(_stateFilePath).Trim().ToLowerInvariant();
            var isLocked = content switch
            {
                "locked" => true,
                "unlocked" => false,
                _ => throw new InvalidDataException($"Invalid hyprlock state: '{content}'. Expected 'locked' or 'unlocked'.")
            };

            DispatchStateChange(isLocked);
        }
        catch (IOException ex)
        {
            GD.PrintErr($"HyprlockWrapperProvider: IO error reading state file - {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            GD.PrintErr($"HyprlockWrapperProvider: Access denied reading state file - {ex.Message}");
        }
        catch (InvalidDataException ex)
        {
            GD.PrintErr($"HyprlockWrapperProvider: {ex.Message}");
        }
        catch (Exception ex)
        {
            GD.PrintErr($"HyprlockWrapperProvider: Unexpected error - {ex.Message}");
        }
    }

    private void DispatchStateChange(bool isLocked)
    {
        // Only dispatch if state actually changed
        if (_lastKnownState == isLocked)
            return;

        _lastKnownState = isLocked;
        var stateEvent = new HyprlockStateEvent(isLocked);
        OnEvent?.Invoke(this, stateEvent);

        var stateText = isLocked ? "LOCKED" : "UNLOCKED";
        var color = isLocked ? "red" : "green";
        GD.PrintRich($"[color={color}]HyprlockWrapperProvider: State changed to {stateText}[/color]");
    }
}