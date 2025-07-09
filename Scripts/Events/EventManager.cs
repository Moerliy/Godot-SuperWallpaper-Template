using System;
using System.Collections.Generic;
using Godot;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.EventTypes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;
using SuperWallpaper.Scripts.Events.Providers;
using SuperWallpaper.Scripts.Events.Providers.ExampleCustomProviders;

namespace SuperWallpaper.Scripts.Events;

public partial class EventManager : Node
{
    private readonly List<IEventProvider> _providers = [];

    /// <summary>
    /// Singleton instance of EventManager
    /// </summary>
    public static EventManager Instance { get; } = new();

    private EventManager()
    {
        RegisterProviders([
            new HyprlandEventProvider(),

            // Custom provider for Hyprlock events
            // See HyprlockWrapperProvider.cs for implementation
            //
            // PS: Comment this out if you don't use Hyprlock or don't want to use my wrapper.
            new HyprlockWrapperProvider()
        ]);
    }

    /// <summary>
    /// Add a provider (call before StartAll)
    /// </summary>
    public void RegisterProvider(IEventProvider provider)
    {
        _providers.Add(provider);
        provider.OnEvent += HandleProviderEvent;
    }

    public void RegisterProviders(IEnumerable<IEventProvider> providers)
    {
        foreach (var provider in providers) RegisterProvider(provider);
    }

    private void HandleProviderEvent(object sender, ISystemEvent evt) => Dispatch(evt);

    /// <summary>
    /// Start all providers
    /// </summary>
    public void StartAll() => _providers.ForEach(p => p.Start());

    /// <summary>
    /// Stop all providers
    /// </summary>
    public void StopAll() => _providers.ForEach(p => p.Stop());

    private readonly Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();

    /// <summary>
    /// Subscribe to an event of type TEvent
    /// </summary>
    public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : ISystemEvent
    {
        var type = typeof(TEvent);

        if (!_handlers.ContainsKey(type))
            _handlers[type] = [];

        _handlers[type].Add(handler);
    }

    /// <summary>
    /// Unsubscribe from an event
    /// </summary>
    public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : ISystemEvent
    {
        var type = typeof(TEvent);
        if (_handlers.TryGetValue(type, out var list))
            list.Remove(handler);
    }

    private void Dispatch(ISystemEvent evt)
    {
        var type = evt.GetType();

        if (!_handlers.TryGetValue(type, out var list)) return;

        foreach (var del in list)
        {
            del.DynamicInvoke(evt);
        }
    }
}