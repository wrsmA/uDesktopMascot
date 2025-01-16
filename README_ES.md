# uDesktopMascot

[![Versión de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Lanzamientos](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: Los idiomas mencionados anteriormente (English, 中文, Español, Français) han sido generados mediante traducción automática por GPT-4o-mini. Para la precisión y matices de la traducción, consulte el texto original (日本語).

## Resumen

"uDesktopMascot" es un proyecto de código abierto que muestra un personaje en el escritorio y reproduce reacciones y sonidos en función de la interacción del usuario. Este proyecto ha sido desarrollado utilizando Unity y admite personajes en formato VRM, lo que permite disfrutar fácilmente de personajes favoritos en el escritorio.

## Características
* Carga y muestra archivos VRM ubicados en StreamingAssets. Si hay múltiples, se cargará el que esté al principio de la búsqueda.
* Carga y reproduce archivos de audio ubicados en StreamingAssets/Voice/. Si hay varios, se reproducirán aleatoriamente.
  * El sonido que se reproduce al hacer clic carga y reproduce archivos de audio ubicados en StreamingAssets/Voice/Click/.
* Carga y reproduce archivos musicales ubicados en StreamingAssets/BGM/. Si hay varios, se reproducirán aleatoriamente.
* Adición de la voz por defecto del personaje.
  * La voz por defecto utiliza el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproduce al iniciar la aplicación, al cerrarla y al hacer clic.

# Requisitos
* Unity 6000.0.31f1 (IL2CPP)

# Licencia
* El código está licenciado bajo la [Licencia Apache 2.0](LICENSE).
* Los siguientes activos están licenciados bajo [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/).
  * BGM
  * Modelos
  * Animaciones

# Acerca de los materiales
* La animación del personaje por defecto se creó utilizando [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La fuente es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Se redistribuye bajo la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Los derechos de autor de la fuente pertenecen al autor original (Google).
* La voz por defecto utiliza el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Se ha confirmado previamente el uso con COEIROINK.

# Créditos del creador
* Modelos: "アオゾラ" (Aozora)
* BGM: MidraLab (eisuke)