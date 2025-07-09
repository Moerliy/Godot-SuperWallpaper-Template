using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("minimized")]
public class MinimizedEvent(string windowAddress, bool isMinimized) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public bool IsMinimized { get; } = isMinimized;
}