# Godot SuperWallpaper Template

**Godot SuperWallpaper Template** is your starting point for creating immersive, animated desktop and mobile wallpapers with the Godot Engine. Inspired by Xiaomi’s “Super Wallpaper” concept, this template lets you craft 2D/3D scenes that respond to user interaction and system events.

> **Future Cross-Platform Support**  
> Android, Windows and macOS targets are on the roadmap—stay tuned!

---

## Demo

> **Video Showcase**

https://github.com/IlyaKotomin/Godot-SuperWallpaper-Template/raw/refs/heads/master/assets/preview.mp4

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
  Leverage Godot 4.x’s 2D and 3D systems, animation tools, and scripting API to build rich, interactive wallpapers.

- **Hyprland Live Wallpaper**  
  Seamless integration with the Hyprland compositor on Linux via the `hyprwinwrap` plugin—turn your Godot window into a true desktop background.

- **Screen Locker Example**  
  Includes a ready-to-follow integration guide for **hyprlock** (GPU-accelerated lock screen) in `HYPRLOCK_INTEGRATION.md`.

- **Performance-First**  
  Built-in Finite State Machine (FSM) for adaptive FPS: scale back or pause rendering when idle to save CPU/GPU cycles.

- **Open Source & Extensible**  
  MIT-licensed and ready for community contributions—swap assets, tweak scripts, and extend functionality to your heart’s content.

---

## Getting Started

### 1. Clone & Open

```bash
git clone https://github.com/IlyaKotomin/Godot-SuperWallpaper-Template.git
cd Godot-SuperWallpaper-Template
# Open the project in Godot 4.x
````

### 2. Hyprland (Linux)

1. **Install Prerequisites**

   * Hyprland v0.33.1 or newer
   * `hyprwinwrap` plugin (e.g., via `pacman -S hyprland-plugin-hyprwinwrap` or your distro’s package manager)

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

### 3. Customizing Your Wallpaper

1. **Explore the Scene**

   * Open `res://Main.tscn` (or your chosen entry point).
   * Review camera setup, lighting, and script hooks.

2. **Swap Assets**
   Replace the placeholder meshes, textures, and shaders in `res://assets/` with your own.

3. **Extend Logic**

   * Edit or add GDScript files under `res://scripts/`.
   * Hook into signals (e.g., input events, time of day) for dynamic behavior.

4. **Export Targets**

   * **Linux (Wayland)**: Ready out of the box.
   * **Android** / **Windows** / **macOS**: Templates and export presets will arrive in upcoming releases.

---

## Roadmap

| Status | Feature                                    |
| :----: | ------------------------------------------ |
|   ✔️   | Hyprland integration                       |
|   ✔️   | Hyprlock example                           |
|   ✔️   | Core wallpaper template                    |
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

---

## License

Distributed under the MIT License. See [LICENSE](LICENSE) for details.

---

## Acknowledgments

* **Godot Engine** – powering 2D/3D and animation features
* **Hyprland** – for the Wayland compositor and `hyprwinwrap` plugin
* **Xiaomi Super Wallpapers** – design inspiration

[![Stargazers over time](https://starchart.cc/IlyaKotomin/Godot-SuperWallpaper-Template.svg?variant=adaptive)](https://starchart.cc/IlyaKotomin/Godot-SuperWallpaper-Template)

