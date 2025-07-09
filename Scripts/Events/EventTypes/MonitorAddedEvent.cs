using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("monitoradded")]
public class MonitorAddedEvent(string monitorName) : EventArgs, ISystemEvent
{
    public string MonitorName { get; } = monitorName;
}