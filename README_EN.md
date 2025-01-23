# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

Japanese | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Note**: The languages above (English, 中文, Español, Français) are generated via automatic translation by GPT-4o-mini. For accuracy and nuances in translation, please refer to the original text (Japanese).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Overview](#overview)
  * [Feature List](#feature-list)
  * [Requirements](#requirements)
  * [License](#license)
  * [Materials](#materials)
  * [Creator Credits](#creator-credits)
  * [3rd Party Notices](#3rd-party-notices)
  * [Sponsor](#sponsor)
<!-- TOC -->

## Overview

"uDesktopMascot" is an open-source project that displays characters on your desktop and responds with reactions and sounds based on user interaction. This project is developed using Unity and supports characters in VRM format, allowing you to easily enjoy your favorite character on your desktop.

**Supported Platforms**
* Windows 10/11
* macOS

## Feature List

The application includes the following features. Please refer to the list for details.

You can add external assets by placing them in the StreamingAssets folder.

<details>

<summary>Model & Animation</summary>
* Displays model files placed in StreamingAssets.
  * Supports VRM (1.x, 0.x) format models.
  * Supports GLB/GLTF format models.

</details>

<details>

<summary>Voice & BGM</summary>
* Loads and plays audio files placed under SteamingAssets/Voice/. If there are multiple files, it plays them randomly.
  * The audio played on click is loaded from sound files placed in StreamingAssets/Voice/Click/.
* Loads and plays music files placed under StreamingAssets/BGM/. If there are multiple files, it plays them randomly.
* Default voice for the character:
  * The default voice uses sound from [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * It plays at app launch, app exit, and on clicks.

</details>

<details>

<summary>Application Settings via Text Files</summary>
You can change the application settings using the application_settings.txt file.

The structure of the settings file is as follows:

```txt
[Character]
ModelPath=default.vrm
TexturePaths=test.png
Scale=3
PositionX=0
PositionY=0
PositionZ=0
RotationX=0
RotationY=0
RotationZ=0

[Sound]
VoiceVolume=1
BGMVolume=0.5
SEVolume=1

[Display]
Opacity=1
AlwaysOnTop=True

[Performance]
TargetFrameRate=60
QualityLevel=2
```

</details>

## Requirements
* Unity 6000.0.31f1 (IL2CPP)

## License
* The code is licensed under the [Apache License 2.0](LICENSE).
* The following assets are licensed under [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/):
  * BGM
  * Models

## Materials
* The default character animations are created using animations from the [“VRM Doll Play” animation data set](https://fumi2kick.booth.pm/items/1655686). It has been confirmed that it can be distributed as part of this repository.
* The font used is [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Redistribution of the Noto Sans JP font is under the [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). The copyright of the font belongs to the original author (Google).
* The default voice uses sound from [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Prior confirmation regarding its usage has been obtained from COEIROINK.
* The button icons are sourced from [MingCute](https://github.com/MidraLab/MingCute).

## Creator Credits
* Model: "Aozora"
* BGM: MidraLab (eisuke)
* Software Icon: Yamucha

## 3rd Party Notices

See [NOTICE](./NOTICE.md).

## Sponsor
- Luna
- uezo