using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("openwindow")]
public class OpenWindowEvent(string windowAddress, string workspaceName, string windowClass, string windowTitle)
    : EventArgs, ISystemEvent
{
    public string WindowAddress { get; } = windowAddress;
    public string WorkspaceName { get; } = workspaceName;
    public string WindowClass { get; } = windowClass;
    public string WindowTitle { get; } = windowTitle;
}