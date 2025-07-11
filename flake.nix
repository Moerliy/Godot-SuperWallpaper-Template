{
  description = "Godot animated wallpaper project flake";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
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
      }
    );
}
