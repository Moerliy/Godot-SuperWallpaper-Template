using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("renameworkspace")]
public class RenameWorkspaceEvent(string workspaceId, string newName) : EventArgs, ISystemEvent
{
    public string WorkspaceId { get; } = workspaceId;
    public string NewName { get; } = newName;
}