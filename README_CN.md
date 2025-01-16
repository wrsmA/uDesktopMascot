# uDesktopMascot

[![Unity 版本](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![发布版本](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上述语言（English、中文、Español、Français）是由GPT-4o-mini进行自动翻译生成的。关于翻译的准确性和细微差别，请参考原文（日本语）。

## 概要

「uDesktopMascot」是一个开源项目，它在桌面上显示角色，并根据用户的互动进行响应和播放声音。该项目是基于Unity开发的，支持VRM格式的角色，使您可以轻松地在桌面上欣赏自己喜欢的角色。

## 特性
* 从StreamingAssets目录加载并显示任意VRM文件。如果有多个，优先加载第一个。
* 从StreamingAssets/Voice/目录加载并播放音频文件。如果有多个，将随机播放。
  * 点击时播放的音频，从StreamingAssets/Voice/Click/目录加载并播放音频文件。
* 从SteamingAssets/BGM/目录加载并播放音乐文件。如果有多个，将随机播放。
* 添加了角色的默认音声
  * 默认音声使用的是[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。
  * 在应用启动、应用退出和点击时播放。

# 需求
* Unity 6000.0.31f1 (IL2CPP)

# 许可
* 代码基于[Apache License 2.0](LICENSE)进行许可。
* 以下素材根据[CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/)进行许可。
  * BGM
  * 模型
  * 动画

# 素材说明
* 默认的角色动画是使用[Unity Muse Animate](https://muse.unity.com/ja-jp/explore)制作的。
* 字体为[Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。基于[SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan)重新分发Noto Sans JP字体。字体的版权归原作者（Google）所有。
* 默认音声使用的是[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。使用方法已经提前向COEIROINK确认过。

# 制作人员致谢
* 模型: 「アオゾラ」様
* BGM: MidraLab(eisuke)