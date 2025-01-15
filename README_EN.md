# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

[日本語](README.md) | English | [中文](README_CN.md)

This is an open project for a desktop mascot.

## Features
* Loads and displays any VRM file placed in the StreamingAssets folder. If there are multiple files, it loads the first one found.
* Loads and plays audio files placed in the `StreamingAssets/Voice/` folder. If there are multiple files, it plays one randomly.
    * The audio played upon clicking is loaded from the files placed in `StreamingAssets/Voice/Click/`.
* Loads and plays music files from the `StreamingAssets/BGM/` folder. If there are multiple files, it plays one randomly.

# Requirements
* Unity 6000.0.31f1

# About the Assets
* The default character animations are created using [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* The default background music (BGM) is an asset created within MidraLab.
* The font used is [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). It is redistributed under the [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). The copyright of the font belongs to the original author (Google).
* The default voice is from [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Prior confirmation regarding usage has been obtained from COEIROINK.