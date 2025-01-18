# uDesktopMascot

[![Versión de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Versiones](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: los idiomas mencionados anteriormente (English, 中文, Español, Français) han sido generados mediante traducción automática por GPT-4o-mini. Para la precisión y matices de la traducción, por favor, consulte el texto original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Resumen](#resumen)
  * [Lista de funciones](#lista-de-funciones)
  * [Requisitos](#requisitos)
  * [Licencia](#licencia)
  * [Sobre los materiales](#sobre-los-materiales)
  * [Créditos de los creadores](#creditos-de-los-creadores)
  * [Avisos de terceros](#avisos-de-terceros)
<!-- TOC -->

## Resumen

"uDesktopMascot" es un proyecto de código abierto que muestra personajes en el escritorio y reproduce reacciones y sonidos en función de las interacciones del usuario. Este proyecto se desarrolla utilizando Unity y admite personajes en formato VRM, lo que permite disfrutar fácilmente de los personajes favoritos en el escritorio.

## Lista de funciones

La aplicación implementa las siguientes funciones. Para más detalles, consulte la lista a continuación.

<details>

<summary>Lista de funciones</summary>

* Carga y muestra archivos VRM ubicados en StreamingAssets. Si hay varios, carga el primero encontrado en la búsqueda. Es compatible con VRM 0.x y VRM 1.x.
* Carga y reproduce archivos de audio ubicados en SteamingAssets/Voice/. Si hay varios, se reproducen aleatoriamente.
  * Los sonidos reproducidos al hacer clic se cargan y reproducen desde los archivos de audio ubicados en StreamingAssets/Voice/Click/.
* Carga y reproduce archivos de música ubicados en SteamingAssets/BGM/. Si hay varios, se reproducen aleatoriamente.
* Adición de la voz predeterminada del personaje.
  * La voz predeterminada utiliza el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproduce al iniciar la aplicación, al cerrarla y al hacer clic.

</details>

## Requisitos
* Unity 6000.0.31f1(IL2CPP)

## Licencia
* El código está licenciado bajo la [Licencia Apache 2.0](LICENSE).
* Los siguientes activos están licenciados bajo [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/):
  * BGM
  * Modelos
  * Animaciones

## Sobre los materiales
* Las animaciones del personaje predeterminado se crean utilizando [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La fuente utilizada es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Esta fuente se redistribuye bajo la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Los derechos de autor de la fuente pertenecen al autor original (Google).
* La voz predeterminada utiliza el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Se ha confirmado previamente el uso con COEIROINK.

## Créditos de los creadores
* Modelos: "アオゾラ" (Aozora)
* BGM: MidraLab (eisuke)

## Avisos de terceros

Consulte [NOTICE](./NOTICE.md).