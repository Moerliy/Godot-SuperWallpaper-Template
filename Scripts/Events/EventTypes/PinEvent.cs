using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("pin")]
public class PinEvent(string windowAddress, bool pinState) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public bool PinState { get; } = pinState;
}