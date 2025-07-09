using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("focusedmonv2")]
public class FocusedMonV2Event(string monitorName, string workspaceId) : EventArgs, ISystemEvent
{
    public string MonitorName { get; } = monitorName;
    public string WorkspaceId { get; } = workspaceId;
}
