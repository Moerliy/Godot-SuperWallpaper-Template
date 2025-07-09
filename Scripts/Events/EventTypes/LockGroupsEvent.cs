using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("lockgroups")]
public class LockGroupsEvent(bool isLocked) : EventArgs, ISystemEvent
{
    public bool IsLocked { get; } = isLocked;
}