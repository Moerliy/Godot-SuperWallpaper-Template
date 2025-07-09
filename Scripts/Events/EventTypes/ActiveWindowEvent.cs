using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("activewindow")]
public class ActiveWindowEvent(string windowClass, string windowTitle) : EventArgs, ISystemEvent
{
    public string WindowClass { get; } = windowClass;
    public string WindowTitle { get; } = windowTitle;
}