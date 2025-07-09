using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("windowtitle")]
public class WindowTitleEvent(string windowAddress) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
}