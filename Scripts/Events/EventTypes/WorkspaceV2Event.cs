using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("workspacev2")]
public class WorkspaceV2Event(int workspaceId, string workspaceName) : EventArgs, ISystemEvent
{
    public int WorkspaceId { get; } = workspaceId;
    public string WorkspaceName { get; } = workspaceName;
}