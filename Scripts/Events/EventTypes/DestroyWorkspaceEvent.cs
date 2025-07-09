using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("destroyworkspace")]
public class DestroyWorkspaceEvent(string workspaceName) : EventArgs, ISystemEvent
{
    public string WorkspaceName { get; } = workspaceName;
}
