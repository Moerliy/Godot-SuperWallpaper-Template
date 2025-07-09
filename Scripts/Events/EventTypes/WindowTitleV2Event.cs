using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("windowtitlev2")]
public class WindowTitleV2Event(string windowAddress, string windowTitle) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public string WindowTitle { get; } = windowTitle;
}