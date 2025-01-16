# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**注意**: 上記の言語（English、中文、Español、Français）は、GPT-4o-miniによる自動翻訳で生成されています。翻訳の精度やニュアンスに関しては、原文（日本語）をご参照ください。

## 概要

「uDesktopMascot」は、デスクトップ上にキャラクターを表示し、ユーザーのインタラクションに応じた反応や音声を再生するオープンソースのプロジェクトです。このプロジェクトは、Unityを用いて開発されており、VRM形式のキャラクターをサポートしていますので、自分の好きなキャラクターを簡単にデスクトップ上で楽しむことができます。


## Features
* StreamingAssetsに配置した任意VRMファイルを読み込んで表示します。複数ある場合は、検索の先頭にあるものを読み込みます。
* SteamingAssets/Voice/以下に配置した音声ファイルを読み込んで再生します。複数ある場合は、ランダムで再生します。
  * クリック時に再生される音声は、StreamingAssets/Voice/Click/に配置した音声ファイルを読み込んで再生します。 
* SteamingAssets/BGM/以下に配置した音楽ファイルを読み込んで再生します。複数ある場合は、ランダムで再生します。
* キャラクターのデフォルトのボイスの追加
  * デフォルトのボイスは、[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)の音声を使用しています。
  * アプリ起動時、アプリ終了時、クリック時に再生されます。

# requirements
* Unity 6000.0.31f1(IL2CPP)

# license
* コードは[Apache License 2.0](LICENSE)に基づいてライセンスされています。
* 以下のアセットは、[CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/)に基づいてライセンスされています。
  * BGM
  * モデル
  * アニメーション

# 素材について
* デフォルトのキャラクターアニメーションは、[Unity Muse Animate](https://muse.unity.com/ja-jp/explore)を用いて作成されています。
* フォントは[Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan)です。[SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan)に基づきNoto Sans JPフォントを再配布するものです。フォントの著作権は元の作者（Google）にあります。
* デフォルトボイスは、[COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan)の音声を使用しています。使用方法については、COEIROINK側に事前に確認済みです

# 制作者クレジット
* モデル: 「アオゾラ」様
* BGM: MidraLab(eisuke)

## 3rd Party Notices

See [NOTICE](./NOTICE.md).