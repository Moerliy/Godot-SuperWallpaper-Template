using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("togglegroup")]
public class ToggleGroupEvent(bool state, string[] handles) : EventArgs, ISystemEvent
{
    public bool State { get; } = state;
    public string[] Handles { get; } = handles;
}