using System;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Attributes;
using hyprlandsuperwallpapertemplate.Scripts.Events.Contracts.Interfaces;

namespace hyprlandsuperwallpapertemplate.Scripts.Events.EventTypes;

[HyprlandEvent("activelayout")]
public class ActiveLayoutEvent(string keyboardName, string layoutName) : EventArgs, ISystemEvent
{
    public string KeyboardName { get; } = keyboardName;
    public string LayoutName { get; } = layoutName;
}
