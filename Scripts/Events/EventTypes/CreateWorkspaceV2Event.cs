using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("createworkspacev2")]
public class CreateWorkspaceV2Event(string workspaceId, string workspaceName) : EventArgs, ISystemEvent
{
    public string WorkspaceId { get; } = workspaceId;
    public string WorkspaceName { get; } = workspaceName;
}
