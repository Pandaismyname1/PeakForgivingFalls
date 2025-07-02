# Peak Forgiving Falls

A BepInEx plugin for PEAK that makes climbing more forgiving by preventing accidental falls when running out of stamina.

## Features

- Prevents instant falling when running out of stamina while climbing
- Creates a more forgiving climbing experience
- Allows players to recover and continue climbing even after a brief stamina loss

## Installation

### Manual Installation

1. Install [BepInEx](https://github.com/BepInEx/BepInEx) if you haven't already
2. Extract the release zip file into your PEAK game directory
3. Make sure the mod DLL is placed in the `BepInEx/plugins` folder

### Thunderstore Installation (Recommended)

1. Install the mod via [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager)
2. Launch the game

## Configuration

Currently, there are no configuration options. The mod works automatically after installation.

## Compatibility

- Designed for PEAK version: Latest Steam release
- BepInEx 5.x

## For Developers

### Building from Source

1. Clone the repository
2. Update the `PeakDir` property in the `PeakForgivingFalls.csproj` file to point to your PEAK installation
3. Build the solution using your preferred IDE or via command line:
   ```
   dotnet build
   ```

## Credits

- Created with BepInEx plugin template

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

If you encounter any issues or have suggestions, please create an issue on the GitHub repository.
