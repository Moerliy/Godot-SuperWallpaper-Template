using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("fullscreen")]
public class FullscreenEvent(bool isFullscreen) : EventArgs, ISystemEvent
{
    public bool IsFullscreen { get; } = isFullscreen;
}