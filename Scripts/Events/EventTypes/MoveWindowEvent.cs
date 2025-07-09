using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("movewindow")]
public class MoveWindowEvent(string windowAddress, string workspaceName) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public string WorkspaceName { get; } = workspaceName;
}