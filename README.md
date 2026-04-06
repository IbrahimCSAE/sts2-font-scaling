## STS2 Font Scaler Mod

This repository contains a Slay the Spire 2 mod that adds font scaling controls to the game.  
The mod allows players to either scale text as a percentage of the default size or force all supported fonts to a fixed pixel size (from 14px to 60px).  
It captures most UI controls, including combat HUD, menus, tooltips, and compendium entries, and keeps them in sync with the chosen font mode.

### Building
1. Install the `Alchyr.Sts2.Templates` (.NET templates) and the Slay the Spire 2 modding toolchain (BaseLib, Godot 4.5.1 mono, etc.).
2. Restore packages and build:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Copy the resulting DLL, JSON manifest, and PCK into your `Slay the Spire 2/mods/FontScalerMod` folder, or run the build from within the repository to use the existing MSBuild targets that auto-copy them.

### Configuration
Inside the game, open Settings → Mod Settings → Font Scaler to:
- Switch between **Percentage** or **Fixed** font modes.
- Adjust the percentage slider (100%–300%).
- Choose an absolute font size when Fixed mode is enabled (14px–60px).

Changes take effect immediately across most UI screens.
