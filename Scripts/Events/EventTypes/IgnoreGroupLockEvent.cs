using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("ignoregrouplock")]
public class IgnoreGroupLockEvent(bool isIgnored) : EventArgs, ISystemEvent
{
    public bool IsIgnored { get; } = isIgnored;
}