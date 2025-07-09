using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("createworkspace")]
public class CreateWorkspaceEvent(string workspaceName) : EventArgs, ISystemEvent
{
    public string WorkspaceName { get; } = workspaceName;
}
