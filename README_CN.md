# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上述语言（English、中文、Español、Français）由GPT-4o-mini自动翻译生成。翻译的准确性和细微差别请参考原文（日本语）。

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [概述](#概述)
  * [功能列表](#功能列表)
  * [要求](#要求)
  * [许可](#许可)
  * [素材说明](#素材说明)
  * [制作人致谢](#制作人致谢)
  * [第三方通知](#第三方通知)
  * [赞助](#赞助)
<!-- TOC -->

## 概述

「uDesktopMascot」是一个开源项目，旨在桌面上显示角色并根据用户的互动进行反应和播放声音。该项目使用Unity开发，支持VRM格式的角色，使用户可以轻松在桌面上享受自己喜欢的角色。

**支持平台**
* Windows 10/11
* macOS

## 功能列表

应用程序中实现了以下功能。详细信息请参见以下列表。

通过将外部资源放置在StreamingAssets文件夹中可以实现导入。

<details>

<summary>模型与动画</summary>
* 加载并显示放置在StreamingAssets中的任意模型文件。
  * 支持VRM(1.x, 0.x)格式模型。
  * 支持GLB/GLTF格式模型。

</details>

<details>

<summary>声音与背景音乐</summary>
* 加载并播放放置在SteamingAssets/Voice/下的音频文件。如果有多个文件，将随机播放。
  * 点击时播放的声音，从StreamingAssets/Voice/Click/中加载音频文件播放。
* 加载并播放放置在SteamingAssets/BGM/下的音乐文件。如果有多个文件，将随机播放。
* 角色的默认声音添加
  * 默认声音使用[COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。
  * 在应用启动、应用关闭和点击时播放。

</details>

<details>

<summary>通过文本文件进行应用设置</summary>
通过application_settings.txt文件可以更改应用程序的设置。

设置文件的结构如下所示

```txt
[Character]
ModelPath=default.vrm
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

## 要求
* Unity 6000.0.31f1(IL2CPP)

## 许可
* 代码根据[Apache License 2.0](LICENSE)进行授权。
* 以下资源基于[CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/)进行授权。
  * 背景音乐
  * 模型

## 素材说明
* 默认角色动画使用了[『VRMお人形遊び』用动画数据合集](https://fumi2kick.booth.pm/items/1655686)制作。已确认可以在仓库中分发。
* 字体为[Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。这是基于[SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan)重新分发Noto Sans JP字体的版本。字体的版权属于原作者（Google）。
* 默认音声使用[COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。使用方法已提前确认。
* 按钮图标使用了[MingCute](https://github.com/MidraLab/MingCute)。

## 制作人致谢
* 模型: 「アオゾラ」様
* 背景音乐: MidraLab(eisuke)
* 软件图标: やむちゃ様

## 第三方通知

请参阅[NOTICE](./NOTICE.md)。

## 赞助
- Luna
- uezo