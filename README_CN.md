# uDesktopMascot

[![Unity 版本](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![版本发布](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上述语言（English、中文、Español、Français）是由 GPT-4o-mini 自动翻译生成的。有关翻译的准确性和细微差别，请参考原文（日本语）。

## 概要

「uDesktopMascot」是一个开源项目，用于在桌面上显示角色，并根据用户的互动进行反应和播放声音。该项目使用 Unity 开发，支持 VRM 格式的角色，用户可以轻松地在桌面上享受自己喜欢的角色。

## 功能
* 加载并显示放置在 StreamingAssets 中的任意 VRM 文件。如果有多个文件，则优先加载搜索结果的第一个。
* 加载并播放放置在 SteamingAssets/Voice/ 目录下的音频文件。如果有多个文件，则随机播放。
  * 点击时播放的音频从 StreamingAssets/Voice/Click/ 目录中的音频文件加载并播放。
* 加载并播放放置在 SteamingAssets/BGM/ 目录下的音乐文件。如果有多个文件，则随机播放。
* 添加角色的默认声音
  * 默认声音使用 [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan) 的音频。
  * 应用启动时、应用结束时和点击时播放。

# 需求
* Unity 6000.0.31f1（IL2CPP）

# 许可
* 代码根据 [Apache License 2.0](LICENSE) 进行授权。
* 以下资产根据 [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) 进行授权。
  * BGM
  * 模型
  * 动画

# 素材说明
* 默认的角色动画是使用 [Unity Muse Animate](https://muse.unity.com/ja-jp/explore) 制作的。
* 字体是 [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。根据 [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan) 再分发 Noto Sans JP 字体。字体的版权归原作者（Google）所有。
* 默认声音使用 [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan) 的音频。使用方法已与 COEIROINK 方面事先确认。

# 制作人员致谢
* 模型:「アオゾラ」先生
* BGM: MidraLab（eisuke）