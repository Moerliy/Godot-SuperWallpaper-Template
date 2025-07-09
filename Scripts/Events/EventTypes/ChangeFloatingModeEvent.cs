using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("changefloatingmode")]
public class ChangeFloatingModeEvent(string windowAddress, bool isFloating) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public bool IsFloating { get; } = isFloating;
}