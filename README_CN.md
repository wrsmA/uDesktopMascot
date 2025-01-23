# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上述语言（English、中文、Español、Français）是通过 GPT-4o-mini 自动翻译生成的。有关翻译的准确性和细微差别，请参考原文（日本语）。

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [概要](#概要)
  * [功能列表](#功能列表)
  * [要求](#要求)
  * [许可证](#许可证)
  * [素材说明](#素材说明)
  * [创作者致谢](#创作者致谢)
  * [第三方通知](#3rd-party-notices)
  * [赞助商](#sponsor)
<!-- TOC -->

## 概要

“uDesktopMascot”是一个开源项目，可以在桌面上显示角色，并根据用户的互动作出反应或播放语音。该项目使用 Unity 开发，支持 VRM 格式的角色，用户可以轻松地在桌面上享受自己喜欢的角色。

**支持平台**
* Windows 10/11
* macOS

## 功能列表

该应用程序实现了以下功能。详细信息请参见以下列表。

通过将外部资产放入 StreamingAssets 文件夹，可以实现添加。

<details>

<summary>模型与动画</summary>
* 加载并显示放置在 StreamingAssets 中的任意模型文件。
  * 支持 VRM(1.x, 0.x) 格式的模型。
  * 支持 GLB/GLTF 格式的模型。

</details>

<details>

<summary>语音与背景音乐</summary>
* 加载并播放放置在 SteamingAssets/Voice/ 目录下的音频文件。如果有多个文件，将随机播放。
  * 点击时播放的音频为加载并播放放置在 StreamingAssets/Voice/Click/ 目录下的音频文件。
* 加载并播放放置在 SteamingAssets/BGM/ 目录下的音乐文件。如果有多个文件，将随机播放。
* 添加角色的默认语音
  * 默认的语音使用[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。
  * 在应用启动、应用结束和点击时播放。

</details>

<details>

<summary>文本文件配置应用程序设置</summary>
你可以通过 application_settings.txt 文件改变应用程序的设置。

配置文件的结构如下：

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
* 代码根据 [Apache License 2.0](LICENSE) 进行授权。
* 以下资产根据 [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) 进行授权。
  * 背景音乐
  * 模型

## 素材说明
* 默认角色动画使用了[『VRMお人形遊び』用アニメーションデータ詰め合わせ](https://fumi2kick.booth.pm/items/1655686)制作。已确认可以在仓库中分发。
* 字体为[Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。根据[SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan)重新分发 Noto Sans JP 字体。字体的版权归原作者（Google）所有。
* 默认语音使用[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的音频。使用方式已经事先确认。
* 按钮图标使用了[MingCute](https://github.com/MidraLab/MingCute)。

## 创作者致谢
* 模型: “アオゾラ” 様
* 背景音乐: MidraLab(eisuke)
* 软件图标: やむちゃ 様

## 第三方通知

见 [NOTICE](./NOTICE.md)。

## 赞助商
- Luna
- uezo