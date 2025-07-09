# Godot SuperWallpaper Template

**Godot SuperWallpaper Template** is your starting point for creating immersive, animated desktop and mobile wallpapers with the Godot Engine. Inspired by Xiaomi's "Super Wallpaper" concept, this template lets you craft 2D/3D scenes that respond to user interaction and system events.

> **Future Cross-Platform Support**  
> Android, Windows and macOS targets are on the roadmap—stay tuned!

---

## Demo

> **Video Showcase**

https://github.com/user-attachments/assets/bd9027fb-9012-45a1-9607-4b494ed0d321

---

## 📖 Documentation

📚 **[Visit our Wiki](../../wiki)** for comprehensive guides and documentation:

- **[Using the Template](../../wiki/Using-the-Template)** - Get started quickly with setup and basic customization
- **[Project Structure](../../wiki/Project-Structure)** - Understand the codebase organization
- **[Hyprland Configuration](../../wiki/Hyprland-Configuration)** - Configure Hyprland to work with wallpapers
- **[Setting up Hyprlock](../../wiki/Setting-up-Hyprlock-with-SuperWallpaper)** - Integrate with screen lock events
- **[Event System Overview](../../wiki/Hyprland-IPC-Event-System-Overview)** - Learn about the reactive event system
- **[Custom Events and Providers](../../wiki/Custom-Events-and-Providers)** - Extend functionality with your own events

---

## 📖 Table of Contents

1. [Features](#features)  
2. [Demo](#demo)  
3. [Getting Started](#getting-started)  
   - [1. Clone & Open](#1-clone--open)  
   - [2. Hyprland (Linux)](#2-hyprland-linux)  
   - [3. Customizing Your Wallpaper](#3-customizing-your-wallpaper)  
4. [Roadmap](#roadmap)  
5. [Contributing](#contributing)  
6. [License](#license)  
7. [Acknowledgments](#acknowledgments)

---

## Features

- **Godot-Powered**  
  Leverage Godot 4.x's 2D and 3D systems, animation tools, and scripting API to build rich, interactive wallpapers.

- **Hyprland Live Wallpaper**  
  Seamless integration with the Hyprland compositor on Linux via the `hyprwinwrap` plugin—turn your Godot window into a true desktop background.

- **Event-Driven System**  
  Built-in event system that responds to workspace changes, window events, and screen lock/unlock states. See **[Event System Overview](../../wiki/Hyprland-IPC-Event-System-Overview)** for details.

- **Screen Locker Integration**  
  Ready-to-use integration with **hyprlock** for lock screen animations. Follow our **[Setting up Hyprlock](../../wiki/Setting-up-Hyprlock-with-SuperWallpaper)** guide.

- **Open Source & Extensible**  
  MIT-licensed and ready for community contributions—swap assets, tweak scripts, and extend functionality. Learn about **[Custom Events and Providers](../../wiki/Custom-Events-and-Providers)**.

---

## Getting Started

### 1. Clone & Open

```bash
git clone https://github.com/IlyaKotomin/Godot-SuperWallpaper-Template.git
cd Godot-SuperWallpaper-Template
# Open the project in Godot 4.x
```

📖 **Detailed Setup**: Follow our **[Using the Template](../../wiki/Using-the-Template)** guide for step-by-step instructions.

### 2. Hyprland (Linux)

1. **Install Prerequisites**

   * Hyprland v0.33.1 or newer
   * `hyprwinwrap` plugin (e.g., via `pacman -S hyprland-plugin-hyprwinwrap` or your distro's package manager)

2. **Launch the Wallpaper**

   * In Godot, export or run the project.
   * The window class is set to `hyprland-super-wallpaper-template`.

3. **Configure Hyprland**
   Add to `~/.config/hypr/hyprland.conf`:

   ```ini
   plugin {
       # …other plugins…
       hyprwinwrap {
           class = hyprland-super-wallpaper-template
       }
   }
   ```

4. **Autostart on Login** (optional)
   Append below the plugin block:

   ```ini
   exec-once = /path/to/your/wallpaper_executable_or_script &
   ```

5. **Enjoy!**
   Reload or log in—your wallpaper will run behind all windows.

📖 **Complete Configuration Guide**: See **[Hyprland Configuration](../../wiki/Hyprland-Configuration)** for detailed setup instructions and troubleshooting.

### 3. Customizing Your Wallpaper

1. **Explore the Scene**

   * Open `res://Main.tscn` (or your chosen entry point).
   * Review camera setup, lighting, and script hooks.

2. **Swap Assets**
   Replace the placeholder meshes, textures, and shaders in `res://assets/` with your own.

3. **Extend Logic**

   * Edit or add C# files under the Scripts directory.
   * Hook into the event system for dynamic behavior that responds to workspace changes, window events, and more.

4. **Export Targets**

   * **Linux (Wayland)**: Ready out of the box.
   * **Android** / **Windows** / **macOS**: Templates and export presets will arrive in upcoming releases.

📖 **Architecture Guide**: Understand the codebase with our **[Project Structure](../../wiki/Project-Structure)** documentation.

---

## Roadmap

| Status | Feature                                    |
| :----: | ------------------------------------------ |
|   ✔️   | Hyprland integration                       |
|   ✔️   | Hyprlock example                           |
|   ✔️   | Core wallpaper template                    |
|   ✔️   | Event-driven architecture                  |
|    ⏳   | Unit testing                               |
|    ⏳   | FSM-based dynamic FPS                      |
|   🔜   | Android live-wallpaper export              |
|   🔜   | Windows/macOS wallpaper helpers            |
|   🔜   | Cross-platform build scripts & CI pipeline |

🔜 **Planned** = coming in a future release

---

## Contributing

We welcome all contributions!

1. Fork the repository.
2. Create a feature branch.
3. Add tests if applicable.
4. Submit a pull request and describe your changes.

📖 **Development Guide**: Check our **[Project Structure](../../wiki/Project-Structure)** to understand how to contribute effectively.

---

## License

Distributed under the MIT License. See [LICENSE](LICENSE) for details.

---

## Acknowledgments

* **Godot Engine** – powering 2D/3D and animation features
* **Hyprland** – for the Wayland compositor and `hyprwinwrap` plugin
* **Xiaomi Super Wallpapers** – design inspiration

[![Stargazers over time](https://starchart.cc/IlyaKotomin/Godot-SuperWallpaper-Template.svg?variant=adaptive)](https://starchart.cc/IlyaKotomin/Godot-SuperWallpaper-Template)
