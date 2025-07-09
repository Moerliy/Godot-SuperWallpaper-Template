using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("monitorremovedv2")]
public class MonitorRemovedV2Event(string monitorId, string monitorName, string monitorDescription)
    : EventArgs, ISystemEvent
{
    public string MonitorId { get; } = monitorId;
    public string MonitorName { get; } = monitorName;
    public string MonitorDescription { get; } = monitorDescription;
}