using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("destroyworkspace")]
public class DestroyWorkspaceEvent(string workspaceName) : EventArgs, ISystemEvent
{
    public string WorkspaceName { get; } = workspaceName;
}
