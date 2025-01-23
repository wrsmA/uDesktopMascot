# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上述语言（English、中文、Español、Français）由 GPT-4o-mini 自动翻译生成。翻译的准确性和细微差别，请参考原文（日本语）。

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [概述](#概述)
  * [功能列表](#功能列表)
  * [要求](#要求)
  * [许可证](#许可证)
  * [素材说明](#素材说明)
  * [制作人鸣谢](#制作人鸣谢)
  * [第三方声明](#第三方声明)
  * [赞助商](#赞助商)
<!-- TOC -->

## 概述

“uDesktopMascot”是一个开源项目，可以在桌面上显示角色，并根据用户的互动做出反应或播放声音。该项目是使用 Unity 开发的，支持 VRM 格式的角色，使您可以轻松地在桌面上享受自己喜欢的角色。

**支持平台**
* Windows 10/11
* macOS

## 功能列表

应用程序实现了以下功能。详细信息请参阅下面的列表。

通过将外部资产放置在 StreamingAssets 文件夹中可以实现添加。

<details>

<summary>模型・动画</summary>
* 读取并显示放置在 StreamingAssets 中的任意模型文件。
  * 支持 VRM(1.x, 0.x) 格式的模型。
  * 支持 GLB/GLTF 格式的模型。

</details>

<details>

<summary>语音・背景音乐</summary>
* 读取并播放放置在 SteamingAssets/Voice/ 中的音频文件。如果有多个文件，则随机播放。
  * 点击时播放的音频来自 StreamingAssets/Voice/Click/ 中的音频文件。
* 读取并播放放置在 SteamingAssets/BGM/ 中的音乐文件。如果有多个文件，则随机播放。
* 添加角色的默认语音
  * 默认语音使用的是 [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan) 的声音。
  * 在应用启动时、应用退出时、点击时播放。

</details>

<details>

<summary>通过文本文件进行应用设置</summary>
可以通过 application_settings.txt 文件修改应用程序的设置。

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
* Unity 6000.0.31f1 (IL2CPP)

## 许可证
* 代码根据 [Apache License 2.0](LICENSE) 授权。
* 以下资产根据 [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) 授权。
  * BGM
  * 模型

## 素材说明
* 默认角色动画基于 [『VRMお人形遊び』用动画数据合集](https://fumi2kick.booth.pm/items/1655686) 制作，已确认可包含并分发于此库中。
* 字体使用 [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。根据 [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan) 授权再分发 Noto Sans JP 字体。字体的版权归原作者（Google）所有。
* 默认语音使用 [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan) 的声音，使用方式预先已与 COEIROINK 确认。
* 按钮图标使用 [MingCute](https://github.com/MidraLab/MingCute)。

## 制作人鸣谢
* 模型: “アオゾラ” 様
* BGM: MidraLab(eisuke)
* 软件图标: やむちゃ 様

## 第三方声明

请参阅 [NOTICE](./NOTICE.md)。

## 赞助商
- Luna
- uezo