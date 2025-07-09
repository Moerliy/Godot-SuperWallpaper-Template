using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("focusedmonv2")]
public class FocusedMonV2Event(string monitorName, string workspaceId) : EventArgs, ISystemEvent
{
    public string MonitorName { get; } = monitorName;
    public string WorkspaceId { get; } = workspaceId;
}
