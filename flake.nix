{
  description = "Godot project flake with nix run support";

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

        exportGodot =
          {
            preset ? "Linux",
            outputName ? "game.x86_64",
            godotPkg ? pkgs.godot_4,
            exportTemplates ? pkgs.godot_4-export-templates,
          }:
          pkgs.stdenv.mkDerivation {
            pname = "godot-export";
            version = "1.0";
            src = self;

            nativeBuildInputs = [ godotPkg ];

            buildPhase = ''
              mkdir -p $out/bin

              export HOME=$TMPDIR
              mkdir -p $HOME/.local/share/godot/export_templates/4.4.1.stable.mono/

              cp -r ${exportTemplates}/templates/* $HOME/.local/share/godot/export_templates/4.4.1.stable.mono/
              # print
              ls -a $HOME/.local/share/godot/export_templates/

              ${godotPkg}/bin/godot-mono --headless --export-release "${preset}" $out/bin/${outputName}
              chmod +x $out/bin/${outputName}
            '';

            installPhase = "true";
          };
      in
      {
        lib.exportGodot = exportGodot;
      }
    );
}
