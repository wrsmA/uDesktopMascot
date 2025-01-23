# uDesktopMascot

[![Unity 版本](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![发布](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上面的语言（English、中文、Español、Français）是由GPT-4o-mini自动翻译生成的。关于翻译的准确性和细微差别，请参阅原文（日本语）。

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [概要](#概要)
  * [功能列表](#功能列表)
  * [要求](#要求)
  * [许可证](#许可证)
  * [素材说明](#素材说明)
  * [制作人员致谢](#制作人员致谢)
  * [第三方通知](#third-party-notices)
  * [赞助](#sponsor)
<!-- TOC -->

## 概要

「uDesktopMascot」是一款开源项目，可以在桌面上显示角色，并根据用户的互动进行反应或播放声音。该项目使用Unity进行开发，支持VRM格式的角色，因此用户可以轻松地在桌面上享受自己喜欢的角色。

**支持的平台**
* Windows 10/11
* macOS

## 功能列表

该应用实现了以下功能。详情请查看以下列表。

可以通过将外部资产放置在StreamingAssets文件夹中添加外部资源。

<details>

<summary>模型与动画</summary>
* 读取并显示保存在StreamingAssets中的任意模型文件。
  * 支持VRM(1.x, 0.x)格式的模型。
  * 支持GLB/GLTF格式的模型。

</details>

<details>

<summary>语音与背景音乐</summary>
* 从StreamingAssets/Voice/目录加载并播放的音频文件。如果有多个，将随机播放。
  * 点击时播放的音频文件来自StreamingAssets/Voice/Click/目录。
* 从StreamingAssets/BGM/目录加载并播放的音乐文件。如果有多个，将随机播放。
* 默认角色语音的添加
  * 默认语音使用[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的声音。
  * 在应用启动时、应用退出时和点击时播放。

</details>

<details>

<summary>通过文本文件进行应用设置</summary>
可以通过application_settings.txt文件更改应用程序设置。

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
* Unity 6000.0.31f1(IL2CPP)

## 许可证
* 代码根据[Apache License 2.0](LICENSE)授权。
* 以下资产根据[CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/)授权：
  * 背景音乐（BGM）
  * 模型

## 素材说明
* 默认的角色动画使用[『VRMお人形遊び』用动画数据包](https://fumi2kick.booth.pm/items/1655686)进行创建。已确认可以在该仓库中包含并分发。
* 字体为[Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。根据[SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan)进行再分发。字体的版权属于原作者（Google）。
* 默认语音使用[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)的声音。使用方法事先已向COEIROINK确认。
* 按钮图标使用[MingCute](https://github.com/MidraLab/MingCute)。

## 制作人员致谢
* 模型: 「アオゾラ」様
* 背景音乐: MidraLab(eisuke)
* 软件图标: やむちゃ様

## 第三方通知

请参见[NOTICE](./NOTICE.md)。

## 赞助
- Luna
- uezo