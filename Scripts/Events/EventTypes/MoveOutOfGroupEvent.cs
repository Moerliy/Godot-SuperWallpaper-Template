using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("moveoutofgroup")]
public class MoveOutOfGroupEvent(string windowAddress) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
}