using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes.ExampleCustomEvents;

public class HyprlockStateEvent(bool locked) : EventArgs, ISystemEvent
{
    public bool Locked { get; } = locked;
}