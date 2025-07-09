using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("fullscreen")]
public class FullscreenEvent(bool isFullscreen) : EventArgs, ISystemEvent
{
    public bool IsFullscreen { get; } = isFullscreen;
}