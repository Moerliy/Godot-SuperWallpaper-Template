using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("pin")]
public class PinEvent(string windowAddress, bool pinState) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public bool PinState { get; } = pinState;
}