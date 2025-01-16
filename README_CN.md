# uDesktopMascot

[![Unity 版本](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![版本发布](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md)

这是一个桌面吉祥物的开放项目。

## 特点
* 加载并显示放置在 `StreamingAssets` 中的任意 VRM 文件。如果有多个文件，则加载搜索结果中的第一个。
* 加载并播放放置在 `SteamingAssets/Voice/` 下的音频文件。如果有多个文件，则随机播放。
  * 点击时播放的音频来自于放置在 `StreamingAssets/Voice/Click/` 中的音频文件。
* 加载并播放放置在 `SteamingAssets/BGM/` 下的音乐文件。如果有多个文件，则随机播放。
* 添加角色的默认声音
  * 默认声音使用了 [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan) 的音频。
  * 应用启动时、应用退出时和点击时会播放。

# 系统要求
* Unity 6000.0.31f1 (IL2CPP)

# 关于素材
* 默认的角色动画是使用 [Unity Muse Animate](https://muse.unity.com/ja-jp/explore) 创建的。
* 默认的背景音乐是 MidraLab 内部制作的资产。
* 字体为 [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)。根据 [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan) 重新分发 Noto Sans JP 字体。字体的版权归原作者（Google）所有。
* 默认声音使用了 [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan) 的音频。使用方法已提前得到 COEIROINK 的确认。