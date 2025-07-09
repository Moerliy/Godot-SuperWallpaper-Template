using System;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("workspace")]
public class WorkspaceEvent(string name) : EventArgs, ISystemEvent
{
    public string Name { get; } = name;
}