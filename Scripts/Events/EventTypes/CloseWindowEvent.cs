using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("closewindow")]
public class CloseWindowEvent(string windowAddress) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
}
