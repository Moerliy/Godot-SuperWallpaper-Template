using System;
using System.Collections.Generic;
using Godot;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;
using hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Providers;
using hyprlandsuperwallpapertemplate.Scripts.Events.Providers.ExmapleCustomProviders;

namespace hyprlandsuperwallpapertemplate.Scripts.Events;

public partial class EventManager : Node
{
    private readonly List<IEventProvider> _providers = [];

    /// <summary>
    /// Singleton instance of EventManager
    /// </summary>
    public static EventManager Instance { get; } = new();

    private EventManager()
    {
        var hyprlandProvider = new HyprlandEventProvider();
        var hyprlockProvider = new HyprlockWrapperProvider();
        
        RegisterProvider(hyprlandProvider);
        RegisterProvider(hyprlockProvider);
    }
    
    /// <summary>
    /// Add a provider (call before StartAll)
    /// </summary>
    private void RegisterProvider(IEventProvider provider)
    {
        _providers.Add(provider);
        provider.OnEvent += HandleProviderEvent;
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

    // --- User subscription to events ---

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