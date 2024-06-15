# Auto Rule Tile Generator

**Version:** 1.0.8  
**Author:** Mitchell Opitz  
**Website:** [mitchellopitz.net](https://www.mitchellopitz.net)

## Overview

The Auto Rule Tile Generator is a tool for Unity designed to streamline the creation of rule tiles based on a predefined template and multiple tilemaps. This tool significantly reduces the time and effort required to manually assign sprites, enabling developers to create visually diverse tilemaps quickly and efficiently.

## Features

- **Automatic Rule Tile Generation:** Automatically creates rule tiles from a provided template.
- **Support for Single and Random Tilemaps:** Handles both single tilemap and multiple tilemaps for randomization.
- **Customizable Rule Tile Templates:** Allows the use of custom rule tile templates.
- **Easy Integration:** Seamlessly integrates into your existing Unity projects.

## Requirements

- **Unity Version:** 2021.1 or higher

## Installation

### Using Git URL

1. Open your Unity project.
2. Go to `Window` > `Package Manager`.
3. Click the `+` button in the top-left corner and select `Add package from git URL...`.
4. Enter the following URL:
    ```
    https://github.com/MitchellOpitz/Automatic-Rule-Tile-Generator.git
    ```
5. Click `Add`.
6. If there are dependency issues, ensure that all required packages are installed via the Package Manager.

### Using Local Path (for Development)

1. Clone the repository to your local machine:
    ```
    git clone https://github.com/MitchellOpitz/Automatic-Rule-Tile-Generator.git
    ```
2. Open your Unity project.
3. Go to `Window` > `Package Manager`.
4. Click the `+` button in the top-left corner and select `Add package from disk...`.
5. Navigate to the cloned directory and select the folder containing the `package.json` file.

## Usage

1. **Create an Auto Rule Tile ScriptableObject:**
    - Right-click in the Project window.
    - Select `Create` > `BF Tools` > `Auto Rule Tile`.

2. **Configure the Auto Rule Tile Generator:**
    - Select the newly created AutoTiler asset.
    - Assign your tilemaps in the `Tilemaps` field.
    - (Optional) Assign a rule tile template in the `Rule Tile Template` field.

3. **Generate Rule Tiles:**
    - Click the `Generate Rule Tile` button in the Inspector.

### Tips for Configuration

- Ensure your tilemaps follow the correct template layout for compatibility.
- Use the provided default templates to get started quickly, then customize as needed.
- Validate your rule tile template and tilemaps before generating to avoid errors.
- **Randomizer Feature:** When using a single tilemap, some tiles may appear repetitive. To reduce this, use multiple variant tilemaps. These variants are visually similar but contain subtle differences to create a less repetitive and more natural-looking tilemap.

## Folder Structure

```
MyAutoTileTool/
├── Editor/
│ ├── Autotiler_GUI.cs
│ └── Autotiler_SO.cs
├── Runtime/
│ └── NaturalSortingExtension.cs
├── Resources/
│ ├── RuleTile_Template.asset
│ └── Tilemap_Template.png
├── LICENSE
├── README.md
└── package.json
```

## Contributing

This tool is currently developed solely by me. If you have suggestions for modifications or new features, please submit an issue on [GitHub Issues](https://github.com/MitchellOpitz/Automatic-Rule-Tile-Generator/issues).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For support or inquiries, contact Mitchell Opitz at [mitchell@mitchellopitz.net](mailto:mitchell@mitchellopitz.net) or visit [mitchellopitz.net](https://www.mitchellopitz.net).

If you encounter any issues or have feature requests, please use the GitHub [Issues](https://github.com/MitchellOpitz/Automatic-Rule-Tile-Generator/issues) page.
