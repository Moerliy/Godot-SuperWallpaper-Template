using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("openwindow")]
public class OpenWindowEvent(string windowAddress, string workspaceName, string windowClass, string windowTitle)
    : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public string WorkspaceName { get; } = workspaceName;
    public string WindowClass { get; } = windowClass;
    public string WindowTitle { get; } = windowTitle;
}