# Auto Tile Generator

**Version:** 1.0.0  
**Author:** Mitchell Opitz  
**Website:** [mitchellopitz.net](https://www.mitchellopitz.net)

## Overview

The Auto Tile Generator is a tool for Unity that allows you to automatically generate rule tiles based on a template and a variable number of tilemaps. This tool is particularly useful for quickly creating visually diverse tilemaps without manual sprite assignment.

## Features

- Automatically generates rule tiles from a template
- Supports single and random tilemaps
- Easy integration into your Unity projects
- Customizable rule tile templates

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

1. **Create an Auto Tile ScriptableObject:**
    - Right-click in the Project window.
    - Select `Create` > `BF Tools - Auto Rule Tile`.

2. **Configure the Auto Tile Generator:**
    - Select the newly created AutoTiler asset.
    - Assign your tilemaps in the `Tilemaps` field.
    - Assign a rule tile template in the `Rule Tile Template` field (optional).

3. **Generate Rule Tiles:**
    - Click the `Generate Rule Tile` button in the Inspector.

## Folder Structure

MyAutoTileTool/
├── Editor/
│ ├── Autotiler_GUI.cs
│ └── Autotiler_SO.cs
├── Runtime/
│ └── NaturalSortingExtension.cs
├── Editor Default Resources/
│ └── (Any default resources your editor scripts might need)
├── LICENSE
├── README.md
└── package.json


## Contributing

If you would like to contribute to this project, please fork the repository and submit a pull request. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For support, you can contact Mitchell Opitz at [mitchell@mitchellopitz.net](mailto:mitchell@mitchellopitz.net) or visit [mitchellopitz.net](https://www.mitchellopitz.net).
