using System;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes.ExampleCustomEvents;

public class HyprlockStateEvent(bool locked) : EventArgs, ISystemEvent
{
    public bool Locked { get; } = locked;
}