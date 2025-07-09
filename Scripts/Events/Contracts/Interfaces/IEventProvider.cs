using System;

namespace SuperWallpaper.Scripts.Events.Contracts.Interfaces;

public interface IEventProvider
{
    /// <summary>
    /// Starts the provider (subscription to system hooks, etc.)
    /// </summary>
    void Start();

    /// <summary>
    ///  Stops the provider
    /// </summary>
    void Stop();

    /// <summary>
    /// General event through which the provider sends any of its events
    /// </summary>
    event EventHandler<ISystemEvent> OnEvent;
}