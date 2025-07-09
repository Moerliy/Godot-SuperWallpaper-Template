using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("activespecial")]
public class ActiveSpecialEvent(string workspaceName, string monitorName) : EventArgs, ISystemEvent
{
    public string WorkspaceName { get; } = workspaceName;
    public string MonitorName { get; } = monitorName;
}