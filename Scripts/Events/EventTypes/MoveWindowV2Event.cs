using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("movewindowv2")]
public class MoveWindowV2Event(string windowAddress, string workspaceId, string workspaceName)
    : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public string WorkspaceId { get; } = workspaceId;
    public string WorkspaceName { get; } = workspaceName;
}
