# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

Japanese | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Note**: The above languages (English, 中文, Español, Français) have been auto-translated by GPT-4o-mini. For accuracy and nuances, please refer to the original text (Japanese).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Overview](#overview)
  * [Feature List](#feature-list)
  * [Requirements](#requirements)
  * [License](#license)
  * [Materials Information](#materials-information)
  * [Creator Credits](#creator-credits)
  * [3rd Party Notices](#3rd-party-notices)
  * [Sponsor](#sponsor)
<!-- TOC -->

## Overview

"uDesktopMascot" is an open-source project that displays characters on the desktop and plays reactions and sounds based on user interactions. This project is developed using Unity and supports characters in VRM format, allowing you to easily enjoy your favorite characters on your desktop.

**Supported Platforms**
* Windows 10/11
* macOS

## Feature List

The application includes the following features. Please refer to the list below for more details.

You can add external assets by placing them in the StreamingAssets folder.

<details>

<summary>Models & Animations</summary>
* Displays any model files placed in the StreamingAssets folder.
  * Supports VRM (1.x, 0.x) format models.
  * Supports GLB/GLTF format models.
</details>

<details>

<summary>Voice & BGM</summary>
* Plays audio files placed in SteamingAssets/Voice/. If there are multiple files, one will be played randomly.
  * Audio played on click is loaded from voice files placed in StreamingAssets/Voice/Click/. 
* Plays music files placed in SteamingAssets/BGM/. If there are multiple files, one will be played randomly.
* Default character voice addition
  * The default voice uses audio from [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Played at application startup, application exit, and on click.
</details>

<details>

<summary>Application Settings via Text File</summary>
You can modify the application's settings using the application_settings.txt file.

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