# uDesktopMascot

[![Versión de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Versiones](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: Los idiomas arriba mencionados (English, 中文, Español, Français) han sido generados mediante traducción automática por GPT-4o-mini. Para precisión y matices de la traducción, consulte el texto original (日本語).

## Resumen

“uDesktopMascot” es un proyecto de código abierto que muestra un personaje en el escritorio y reproduce reacciones y sonidos en respuesta a la interacción del usuario. Este proyecto está desarrollado utilizando Unity y soporta personajes en formato VRM, por lo que puedes disfrutar fácilmente de tus personajes favoritos en el escritorio.

## Características
* Carga y muestra cualquier archivo VRM ubicado en StreamingAssets. Si hay múltiples, se carga el primero en la búsqueda.
* Carga y reproduce archivos de audio ubicados en SteamingAssets/Voice/. Si hay varios, se reproducen de manera aleatoria.
  * Los sonidos reproducidos al hacer clic se cargan y reproducen desde los archivos de audio ubicados en StreamingAssets/Voice/Click/.
* Carga y reproduce archivos de música ubicados en SteamingAssets/BGM/. Si hay varios, se reproducen de manera aleatoria.
* Adición de la voz predeterminada del personaje.
  * La voz predeterminada utiliza el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproduce al iniciar la aplicación, al cerrarla y al hacer clic.

# Requisitos
* Unity 6000.0.31f1 (IL2CPP)

# Licencia
* El código está licenciado bajo la [Licencia Apache 2.0](LICENSE).
* Los siguientes activos están licenciados bajo [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/).
  * BGM
  * Modelos
  * Animaciones

# Sobre los materiales
* Las animaciones predeterminadas del personaje están creadas utilizando [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La fuente es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Se redistribuye de acuerdo con la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). El copyright de la fuente pertenece al autor original (Google).
* La voz predeterminada se basa en el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Se ha confirmado previamente con COEIROINK sobre el uso.

# Créditos del creador
* Modelos: “アオゾラ”
* BGM: MidraLab (eisuke)