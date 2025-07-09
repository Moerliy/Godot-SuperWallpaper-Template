using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("createworkspacev2")]
public class CreateWorkspaceV2Event(string workspaceId, string workspaceName) : EventArgs, ISystemEvent
{
    public string WorkspaceId { get; } = workspaceId;
    public string WorkspaceName { get; } = workspaceName;
}
