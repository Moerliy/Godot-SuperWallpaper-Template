using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("moveworkspacev2")]
public class MoveWorkspaceV2Event(string workspaceId, string workspaceName, string monitorName)
    : EventArgs, ISystemEvent
{
    public string WorkspaceId { get; } = workspaceId;
    public string WorkspaceName { get; } = workspaceName;
    public string MonitorName { get; } = monitorName;
}