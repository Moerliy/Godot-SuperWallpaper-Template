using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("minimized")]
public class MinimizedEvent(string windowAddress, bool isMinimized) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public bool IsMinimized { get; } = isMinimized;
}