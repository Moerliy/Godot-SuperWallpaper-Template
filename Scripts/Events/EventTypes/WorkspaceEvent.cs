using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("workspace")]
public class WorkspaceEvent(string name) : EventArgs, ISystemEvent
{
    public string Name { get; } = name;
}