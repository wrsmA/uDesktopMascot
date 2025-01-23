# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**：上述语言（English、中文、Español、Français）是由GPT-4o-mini自动翻译生成的。关于翻译的准确性和细微差别，请参阅原文（日本语）。

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [概述](#概述)
  * [功能列表](#功能列表)
  * [要求](#要求)
  * [许可证](#许可证)
  * [素材说明](#素材说明)
  * [制作人致谢](#制作人致谢)
  * [第三方通知](#第三方通知)
  * [赞助商](#赞助商)
<!-- TOC -->

## 概述

“uDesktopMascot”是一个开源项目，可以在桌面上显示角色，并根据用户的互动做出反应和播放声音。该项目使用Unity进行开发，支持VRM格式的角色，因此您可以轻松地在桌面上享受自己喜欢的角色。

**支持平台**
* Windows 10/11
* macOS

## 功能列表

此应用程序实现了以下功能。有关详细信息，请参阅下面的列表。

通过将外部资产放置到StreamingAssets文件夹中来实现添加。

<details>

<summary>模型・动画</summary>
* 从StreamingAssets中加载和显示任意模型文件。
  * 支持VRM（1.x，0.x）格式的模型。
  * 支持GLB/GLTF格式的模型。

</details>

<details>

<summary>语音・背景音乐</summary>
* 从SteamingAssets/Voice/加载并播放放置的音频文件。如果有多个文件，随机选择播放。
  * 点击时播放的语音从StreamingAssets/Voice/Click/加载并播放。
* 从SteamingAssets/BGM/加载并播放放置的音乐文件。如果有多个文件，随机选择播放。
* 添加角色的默认语音
  * 默认语音使用[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。
  * 在应用启动时、应用退出时、点击时播放。

</details>

<details>

<summary>通过文本文件进行应用程序设置</summary>
通过application_settings.txt文件可以更改应用程序的设置。

设置文件的结构如下所示：

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

## 要求
* Unity 6000.0.31f1（IL2CPP）

## 许可证
* 代码根据[Apache License 2.0](LICENSE)进行许可。
* 以下资产根据[CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/)进行许可。
  * 背景音乐
  * 模型

## 素材说明
* 默认的角色动画使用[《VRM人偶游戏》用动画数据合集](https://fumi2kick.booth.pm/items/1655686)制作。已经确认可以包含在仓库中分发。
* 字体为[Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。根据[SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan)重新分发Noto Sans JP字体。字体的版权归原作者（Google）所有。
* 默认语音使用[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。使用方法已经事先向COEIROINK确认。
* 按钮图标使用[MingCute](https://github.com/MidraLab/MingCute)。

## 制作人致谢
* 模型： “アオゾラ”样
* 背景音乐：MidraLab（eisuke）
* 软件图标：やむちゃ样

## 第三方通知

请参阅[NOTICE](./NOTICE.md)。

## 赞助商
- Luna
- uezo