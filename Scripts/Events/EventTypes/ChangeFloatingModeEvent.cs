using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("changefloatingmode")]
public class ChangeFloatingModeEvent(string windowAddress, bool isFloating) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public bool IsFloating { get; } = isFloating;
}