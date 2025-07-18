{
  description = "Godot animated wallpaper project flake";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";

    # Hyprlock
    hyprlock = {
      url = "github:hyprwm/hyprlock";
      inputs.nixpkgs.follows = "nixpkgs";
    };
  };

  outputs =
    {
      self,
      nixpkgs,
      flake-utils,
      ...
    }:
    flake-utils.lib.eachSystem [ "x86_64-linux" "aarch64-linux" ] (
      system:
      let
        pkgs = import nixpkgs {
          inherit system;
        };
        hyprlock = import hyprlock {
          inherit pkgs;
        };

        # static wrapper script for hyprlock
        hyprlockWrapper = pkgs.writeShellScriptBin "hyprlockWrapper" ''
          #!/usr/bin/env bash
          echo "[hyprlock-wrapper] Script started" >&2

          # Where to write the lock state
          STATE_FILE="$HOME/.cache/hyprlock_state"

          # Ensure the state file exists
          mkdir -p "$(dirname "$STATE_FILE")"
          : > "$STATE_FILE"

          # Initialize with locked state since Hyprlock starts locked
          printf 'locked' > "$STATE_FILE"
          echo "[hyprlock-wrapper] Initial state set to 'locked'" >&2

          # Use stdbuf to disable buffering and process substitution for real-time processing
          ${pkgs.coreutils}/bin/stdbuf -oL -eL ${
            hyprlock.packages.${pkgs.system}.hyprlock
          }/bin/hyprlock 2>&1 | while IFS= read -r line; do
            case "$line" in
              # This line indicates that user has logged in successfully 
              # and Hyprlock is now playing login animation
              *"[LOG] auth: authenticated for hyprlock"*)
                printf 'unlocked' > "$STATE_FILE"
                echo "[hyprlock-wrapper] Unlock event detected, wrote 'unlocked' to $STATE_FILE" >&2
                ;;
            esac
          done

          echo "[hyprlock-wrapper] hyprlock exited" >&2
        '';

        # default values
        defaultGodot = pkgs.godot_4-mono;
        defaultGodotVersion = "4.4.1";
        defaultGodotSha256 = "sha256-tk0WS5axndcXWhuj86blg+nU3FB7PRMzVj8ka1gRgj4=";
        defaultExeName = "animated-wallpaper";
        architectur = if system == "x86_64-linux" then "x86_64" else "arm64";
        architecturInGodotTemp = if system == "x86_64-linux" then "x64" else "arm64";
        godotCofigName = if system == "x86_64-linux" then "Linux" else "LinuxARM";

        mkPackage =
          {
            godot ? defaultGodot,
            godotVersion ? defaultGodotVersion,
            sha256 ? defaultGodotSha256,
            exeName ? defaultExeName,
          }:

          let
            templates = pkgs.godotPackages_4_4.export-template-mono;

            wallpaperBin = pkgs.stdenv.mkDerivation {
              pname = "animated-wallpaper";
              version = "0.1.8";

              src = ./.;

              buildInputs = [
                godot
                pkgs.dotnet-sdk_8
              ];

              buildPhase = ''
                mkdir -p templates
                cp -r ${templates}/libexec/godot.linuxbsd.template_release.${architectur}.mono ./templates/linux_release.${architectur}
                ls -la templates

                mkdir -p build
                # Let Godot build the C# code
                ${godot}/bin/godot-mono --headless --verbose --export-release ${godotCofigName} build/${defaultExeName}.${architectur}
              '';

              installPhase = ''
                mkdir -p $out/bin
                cp -r .godot/mono/temp/bin/ExportRelease/linux-${architecturInGodotTemp}/* $out/bin/
                cp build/${defaultExeName}.${architectur} $out/bin/${defaultExeName}
                chmod +x $out/bin/${defaultExeName}
              '';
            };
          in
          wallpaperBin;
      in
      {
        packages.default = mkPackage { };
        packages.withConfig = mkPackage;
        packages.hyprlockWrapper = hyprlockWrapper;
      }
    );
}
