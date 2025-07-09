using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("focusedmon")]
public class FocusedMonEvent(string monitorName, string workspaceName) : EventArgs, ISystemEvent
{
    public string MonitorName { get; } = monitorName;
    public string WorkspaceName { get; } = workspaceName;
}