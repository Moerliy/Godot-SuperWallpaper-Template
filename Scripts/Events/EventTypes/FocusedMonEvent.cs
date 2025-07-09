using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("focusedmon")]
public class FocusedMonEvent(string monitorName, string workspaceName) : EventArgs, ISystemEvent
{
    public string MonitorName { get; } = monitorName;
    public string WorkspaceName { get; } = workspaceName;
}