using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("screencast")]
public class ScreencastEvent(int state, int owner) : EventArgs, ISystemEvent
{
    public int State { get; } = state;
    public int Owner { get; } = owner;
}
