using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("movewindow")]
public class MoveWindowEvent(string windowAddress, string workspaceName) : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public string WorkspaceName { get; } = workspaceName;
}