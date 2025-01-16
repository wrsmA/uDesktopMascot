# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

Japanese | [English](README_EN.md) | [中文](README_CN.md)

This is an Open Project for a desktop mascot.

## Features
* Loads and displays any VRM files placed in StreamingAssets. If there are multiple, it loads the one that appears first in the search.
* Loads and plays audio files placed in StreamingAssets/Voice/. If there are multiple, they play randomly.
  * The audio played upon clicking is loaded from sound files placed in StreamingAssets/Voice/Click/.
* Loads and plays music files placed in StreamingAssets/BGM/. If there are multiple, they play randomly.
* Addition of the character's default voice.
  * The default voice is sourced from [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * It plays at app startup, app exit, and on clicks.

# Requirements
* Unity 6000.0.31f1 (IL2CPP)

# About the Materials
* The default character animations are created using [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* The default background music (BGM) is an asset created within MidraLab.
* The font used is [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). This is a redistribution of the Noto Sans JP font under the [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). The copyright of the font belongs to the original author (Google).
* The default voice is sourced from [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan). We have confirmed in advance with COEIROINK regarding usage.