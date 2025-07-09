using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("destroyworkspacev2")]
public class DestroyWorkspaceV2Event(string workspaceId, string workspaceName) : EventArgs, ISystemEvent
{
    public string WorkspaceId { get; } = workspaceId;
    public string WorkspaceName { get; } = workspaceName;
}
