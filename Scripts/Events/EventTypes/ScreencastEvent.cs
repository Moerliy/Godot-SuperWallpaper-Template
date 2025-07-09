using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("screencast")]
public class ScreencastEvent(int state, int owner) : EventArgs, ISystemEvent
{
    public int State { get; } = state;
    public int Owner { get; } = owner;
}
