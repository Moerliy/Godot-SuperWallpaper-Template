using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("submap")]
public class SubmapEvent(string submapName) : EventArgs, ISystemEvent
{
    public string SubmapName { get; } = submapName;
}