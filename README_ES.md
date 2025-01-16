Sure! Here is the translation of the provided text into Spanish:

# uDesktopMascot

[![Versión de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Publicaciones](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: Los idiomas mencionados anteriormente (English, 中文, Español, Français) han sido generados mediante traducción automática por GPT-4o-mini. Para la precisión y matices de la traducción, consulte el texto original (日本語).

## Resumen

"uDesktopMascot" es un proyecto de código abierto que muestra un personaje en el escritorio y reproduce reacciones y sonidos en función de la interacción del usuario. Este proyecto se ha desarrollado utilizando Unity y admite personajes en formato VRM, por lo que puedes disfrutar fácilmente de tu personaje favorito en el escritorio.

## Características
* Lee y muestra cualquier archivo VRM colocado en StreamingAssets. Si hay varios, se carga el que se encuentra primero en la búsqueda.
* Lee y reproduce archivos de audio colocados en StreamingAssets/Voice/. Si hay varios, se reproducen de forma aleatoria.
  * Los sonidos que se reproducen al hacer clic se cargan desde los archivos de audio colocados en StreamingAssets/Voice/Click/.
* Lee y reproduce archivos de música colocados en StreamingAssets/BGM/. Si hay varios, se reproducen de forma aleatoria.
* Adición de la voz predeterminada del personaje.
  * La voz predeterminada utiliza audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproduce al iniciar la aplicación, al cerrarla y al hacer clic.

# Requisitos
* Unity 6000.0.31f1(IL2CPP)

# Sobre los materiales
* La animación predeterminada del personaje se ha creado utilizando [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La BGM predeterminada es un asset creado dentro de MidraLab.
* La fuente es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Se redistribuye la fuente Noto Sans JP de acuerdo con la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Los derechos de autor de la fuente pertenecen al autor original (Google).
* La voz predeterminada utiliza audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). El uso ha sido verificado previamente con COEIROINK.