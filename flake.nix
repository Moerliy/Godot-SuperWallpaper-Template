{
  description = "Reusable Godot exporter flake with configurable Godot and templates";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs =
    {
      self,
      nixpkgs,
      flake-utils,
    }:
    flake-utils.lib.eachDefaultSystem (
      system:
      let
        pkgs = import nixpkgs { inherit system; };

        # Export function, configurable via arguments
        exportGodot =
          {
            src,
            preset ? "Linux/X11",
            outputName ? "game.x86_64",
            godotPkg ? pkgs.godot_4,
            exportTemplates ? pkgs.godot_4-export-templates,
          }:

          pkgs.stdenv.mkDerivation {
            pname = "godot-export";
            version = "1.0";
            inherit src;

            nativeBuildInputs = [ godotPkg ];

            GDTEMPLATES = if exportTemplates != null then exportTemplates else "";

            buildPhase = ''
              mkdir -p $out/bin

              # Optionally override export templates directory
              if [ -n "$GDTEMPLATES" ]; then
                export HOME=$PWD/home
                mkdir -p "$HOME/.local/share/godot"
                ln -s "$GDTEMPLATES" "$HOME/.local/share/godot/templates"
              fi

              ${godotPkg}/bin/godot --headless --export-release "${preset}" $out/bin/${outputName}
            '';

            installPhase = "true";
          };
      in
      {
        lib = {
          exportGodot = exportGodot;
        };
      }
    );
}
