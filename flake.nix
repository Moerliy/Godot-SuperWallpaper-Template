{
  description = "Godot game project flake";

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
    flake-utils.lib.eachDefaultSystem (
      system:
      let
        pkgs = import nixpkgs {
          inherit system;
        };

        godot = pkgs.godot_4-mono; # Override here if needed (see section 3)

        godotExportTemplates =
          version: sha256:
          pkgs.runCommand "godot-templates-${version}"
            {
              nativeBuildInputs = [ pkgs.unzip ];
            }
            ''
              mkdir -p $out
              cp ${
                pkgs.fetchurl {
                  url = "https://github.com/godotengine/godot-builds/releases/download/${version}-stable/Godot_v${version}-stable_mono_export_templates.tpz";
                  sha256 = "${sha256}";
                }
              } templates.tpz

              unzip templates.tpz -d $out
            '';
        templates = godotExportTemplates "4.4.1" "sha256-tk0WS5axndcXWhuj86blg+nU3FB7PRMzVj8ka1gRgj4=";

        game = pkgs.stdenv.mkDerivation {
          pname = "my-godot-game";
          version = "0.1.3";

          src = ./.;

          buildInputs = [ godot ];

          # Create export templates etc. if needed
          buildPhase = ''
            #export HOME=$TMPDIR
            #mkdir -p $HOME/.local/share/godot/export_templates/4.4.1.stable.mono/

            #cp -r ${templates}/templates/* $HOME/.local/share/godot/export_templates/4.4.1.stable.mono/

            mkdir -p build
            ${godot}/bin/godot-mono --headless --export-release "Linux" build/my-game.x86_64
          '';

          installPhase = ''
            mkdir -p $out/bin
            # cp build/my-game.pck $out/bin/
            ln build/my-game.x86_64 $out/bin/my-game
            chmod +x $out/bin/my-game
          '';
        };
      in
      {
        packages.default = game;
      }
    );
}
