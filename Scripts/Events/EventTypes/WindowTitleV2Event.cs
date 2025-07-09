using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("windowtitlev2")]
public class WindowTitleV2Event(string windowAddress, string windowTitle) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public string WindowTitle { get; } = windowTitle;
}