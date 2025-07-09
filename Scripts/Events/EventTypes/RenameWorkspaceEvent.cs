using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("renameworkspace")]
public class RenameWorkspaceEvent(string workspaceId, string newName) : EventArgs, ISystemEvent
{
    public string WorkspaceId { get; } = workspaceId;
    public string NewName { get; } = newName;
}