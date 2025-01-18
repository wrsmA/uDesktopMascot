# uDesktopMascot

[![Unity版本](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![版本发布](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上述语言（English、中文、Español、Français）为GPT-4o-mini自动翻译生成。关于翻译的准确性和微妙之处，请参考原文（日本語）。

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [概述](#概述)
  * [功能列表](#功能列表)
  * [要求](#要求)
  * [许可](#许可)
  * [素材说明](#素材说明)
  * [制作人员致谢](#制作人员致谢)
  * [第三方声明](#第三方声明)
<!-- TOC -->

## 概述

“uDesktopMascot”是一个开源项目，用于在桌面上显示角色，并根据用户的交互做出反应和播音。该项目使用Unity进行开发，支持VRM格式的角色，因此用户可以轻松地在桌面上享受自己喜欢的角色。

## 功能列表

应用程序实现了以下功能。具体细节请参见以下列表。

<details>

<summary>功能列表</summary>

* 读取并显示放置在StreamingAssets中的任意VRM文件。如果有多个，将读取第一个。
* 读取并播放放置在SteamingAssets/Voice/中的音频文件。如果有多个，将随机播放。
  * 在点击时播放的音频来自于放置在StreamingAssets/Voice/Click/中的音频文件。
* 读取并播放放置在SteamingAssets/BGM/中的音乐文件。如果有多个，将随机播放。
* 添加角色的默认音声
  * 默认音声使用的是[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。
  * 在应用程序启动时、退出时以及点击时播放。

</details>

## 要求
* Unity 6000.0.31f1(IL2CPP)

## 许可
* 代码基于[Apache License 2.0](LICENSE)进行许可。
* 以下资产根据[CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/)进行许可。
  * BGM
  * 模型
  * 动画

## 素材说明
* 默认角色动画使用[Unity Muse Animate](https://muse.unity.com/ja-jp/explore)制作。
* 字体为[Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。根据[SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan)重新分发Noto Sans JP字体。字体的版权属于原作者（Google）。
* 默认声音使用的是[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。使用方式已经事先向COEIROINK确认。

## 制作人员致谢
* 模型: 「アオゾラ」様
* BGM: MidraLab(eisuke)

## 第三方声明

请参见[NOTICE](./NOTICE.md)。