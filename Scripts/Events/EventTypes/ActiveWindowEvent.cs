using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("activewindow")]
public class ActiveWindowEvent(string windowClass, string windowTitle) : EventArgs, ISystemEvent
{
    public string WindowClass { get; } = windowClass;
    public string WindowTitle { get; } = windowTitle;
}