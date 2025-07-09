using System;
using SuperWallpaper.Scripts.Events.Contracts;
using SuperWallpaper.Scripts.Events.Contracts.Attributes;
using SuperWallpaper.Scripts.Events.Contracts.Interfaces;

namespace SuperWallpaper.Scripts.Events.EventTypes;

[HyprlandEvent("activelayout")]
public class ActiveLayoutEvent(string keyboardName, string layoutName) : EventArgs, ISystemEvent
{
    public string KeyboardName { get; } = keyboardName;
    public string LayoutName { get; } = layoutName;
}
