# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

Japanese | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Note**: The languages mentioned above (English, 中文, Español, Français) have been generated through automatic translation by GPT-4o-mini. For accuracy and nuances in translation, please refer to the original text (Japanese).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Overview](#overview)
  * [Feature List](#feature-list)
  * [Requirements](#requirements)
  * [License](#license)
  * [Assets Information](#assets-information)
  * [Creator Credits](#creator-credits)
  * [3rd Party Notices](#3rd-party-notices)
  * [Sponsor](#sponsor)
<!-- TOC -->

## Overview

“uDesktopMascot” is an open-source project that displays a character on the desktop and plays reactions or sounds based on user interactions. This project is developed using Unity, and it supports characters in VRM format, allowing you to easily enjoy your favorite characters on your desktop.

**Supported Platforms**
* Windows 10/11
* macOS

## Feature List

The application has the following implemented features. Please refer to the list below for details.

You can add external assets by placing them in the StreamingAssets folder.

<details>

<summary>Models and Animations</summary>
* It loads and displays arbitrary model files placed in StreamingAssets.
  * Supports VRM (1.x, 0.x) format models.
  * Supports GLB/GLTF format models.

</details>

<details>

<summary>Voice and BGM</summary>
* It loads and plays audio files placed in SteamingAssets/Voice/. If there are multiple files, it plays them randomly.
  * The audio played on click is loaded from audio files placed in StreamingAssets/Voice/Click/.
* It loads and plays music files placed in SteamingAssets/BGM/. If there are multiple files, it plays them randomly.
* Default voice for the character:
  * The default voice uses audio from [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * It is played on application start, exit, and click events.

</details>

<details>

<summary>Application Settings via Text File</summary>
You can change the application settings through the application_settings.txt file.

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

## Assets Information
* The default character animations are created using the [“VRM Doll Play” animation data collection](https://fumi2kick.booth.pm/items/1655686). It has been confirmed that redistribution is permitted.
* The font is [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). The Noto Sans JP font is redistributed under the [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). The copyright of the font remains with the original author (Google).
* The default voice uses audio from [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan). It has been confirmed beforehand with COEIROINK regarding its use.
* The button icons use [MingCute](https://github.com/MidraLab/MingCute).

## Creator Credits
* Model: "Aozora"
* BGM: MidraLab (eisuke)
* Software Icon: Yamucha

## 3rd Party Notices

See [NOTICE](./NOTICE.md).

## Sponsor
- Luna
- uezo