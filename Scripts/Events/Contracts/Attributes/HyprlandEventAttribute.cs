using System;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;

/// <summary>
/// This attribute links an event class to the event name in Hyprland IPC.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class HyprlandEventAttribute(string eventName) : Attribute
{
    public string EventName { get; } = eventName;
}