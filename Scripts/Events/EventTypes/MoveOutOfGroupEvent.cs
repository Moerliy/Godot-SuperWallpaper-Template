using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("moveoutofgroup")]
public class MoveOutOfGroupEvent(string windowAddress) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
}