# uDesktopMascot

[![Unity 版本](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)  
[![版本](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上述语言（English、中文、Español、Français）是由GPT-4o-mini自动翻译生成的。有关翻译的准确性和细微差别，请参阅原文（日本语）。

## 概述

“uDesktopMascot”是一个开源项目，旨在桌面上显示角色，并根据用户的互动做出反应和播放声音。该项目基于Unity开发，支持VRM格式的角色，因此您可以轻松地在桌面上享受自己喜欢的角色。

## 特性
* 加载并显示放置在StreamingAssets中的任意VRM文件。如果有多个文件，将加载搜索结果中的第一个。
* 加载并播放放置在SteamingAssets/Voice/中的音频文件。如果有多个文件，将随机播放。
  * 点击时播放的音频是从StreamingAssets/Voice/Click/中加载的音频文件。
* 加载并播放放置在SteamingAssets/BGM/中的音乐文件。如果有多个文件，将随机播放。
* 添加角色的默认声音
  * 默认声音使用[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。
  * 在应用启动时、应用退出时和点击时播放。

# 要求
* Unity 6000.0.31f1(IL2CPP)

# 许可
* 代码依据[Apache License 2.0](LICENSE)进行授权。
* 以下资产依据[CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/)进行授权。
  * 背景音乐 (BGM)
  * 模型
  * 动画

# 关于素材
* 默认角色动画使用[Unity Muse Animate](https://muse.unity.com/ja-jp/explore)创建。
* 字体是[Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。根据[SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan)进行再分发。字体的版权归原作者（Google）所有。
* 默认声音使用[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。使用方法已事先与COEIROINK确认。

# 制作者致谢
* 模型: 「アオゾラ」様
* 背景音乐: MidraLab(eisuke)