using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("monitorremovedv2")]
public class MonitorRemovedV2Event(string monitorId, string monitorName, string monitorDescription)
    : EventArgs, ISystemEvent
{
    public string MonitorId { get; } = monitorId;
    public string MonitorName { get; } = monitorName;
    public string MonitorDescription { get; } = monitorDescription;
}