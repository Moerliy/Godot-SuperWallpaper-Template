using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("togglegroup")]
public class ToggleGroupEvent(bool state, string[] handles) : EventArgs, ISystemEvent
{
    public bool State { get; } = state;
    public string[] Handles { get; } = handles;
}