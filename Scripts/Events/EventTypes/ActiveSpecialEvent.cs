using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("activespecial")]
public class ActiveSpecialEvent(string workspaceName, string monitorName) : EventArgs, ISystemEvent
{
    public string WorkspaceName { get; } = workspaceName;
    public string MonitorName { get; } = monitorName;
}