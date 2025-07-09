using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("monitorremoved")]
public class MonitorRemovedEvent(string monitorName) : EventArgs, ISystemEvent
{
    public string MonitorName { get; } = monitorName;
}