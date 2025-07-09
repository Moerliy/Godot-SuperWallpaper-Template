using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("workspacev2")]
public class WorkspaceV2Event(int workspaceId, string workspaceName) : EventArgs, ISystemEvent
{
    public int WorkspaceId { get; } = workspaceId;
    public string WorkspaceName { get; } = workspaceName;
}