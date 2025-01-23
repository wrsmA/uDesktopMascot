# uDesktopMascot

[![Versión de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Lanzamientos](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: Los idiomas anteriores (English, 中文, Español, Français) han sido generados por traducción automática de GPT-4o-mini. Para medir la precisión y los matices de la traducción, consulte el texto original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Resumen](#resumen)
  * [Lista de funciones](#lista-de-funciones)
  * [requisitos](#requisitos)
  * [licencia](#licencia)
  * [Sobre los materiales](#sobre-los-materiales)
  * [Créditos de los creadores](#creditos-de-los-creadores)
  * [Avisos de terceros](#avisos-de-terceros)
  * [patrocinador](#patrocinador)
<!-- TOC -->

## Resumen

"uDesktopMascot" es un proyecto de código abierto que muestra personajes en el escritorio y reproduce reacciones y sonidos en función de la interacción del usuario. Este proyecto está desarrollado utilizando Unity y soporta personajes en formato VRM, permitiéndote disfrutar fácilmente de tus personajes favoritos en el escritorio.

**Plataformas compatibles**
* Windows 10/11
* macOS

## Lista de funciones

La aplicación incluye las siguientes funciones. Consulta la lista a continuación para más detalles.

Puedes agregar activos externos colocándolos en la carpeta StreamingAssets.

<details>

<summary>Modelos & Animaciones</summary>
* Carga y muestra archivos de modelo colocados en StreamingAssets.
  * Soporta modelos en formato VRM (1.x y 0.x).
  * Soporta modelos en formato GLB/GLTF.

</details>

<details>

<summary>Voz & BGM</summary>
* Carga y reproduce archivos de audio colocados en SteamingAssets/Voice/. Si hay varios, se reproducirán de forma aleatoria.
  * Los sonidos reproducidos al hacer clic se cargan desde archivos de audio colocados en StreamingAssets/Voice/Click/.
* Carga y reproduce archivos musicales colocados en SteamingAssets/BGM/. Si hay varios, se reproducirán de forma aleatoria.
* Añade voces predeterminadas para los personajes.
  * La voz predeterminada utiliza sonidos de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproducirá al inicio de la aplicación, al salir y al hacer clic.

</details>

<details>

<summary>Configuración de la aplicación mediante archivo de texto</summary>
Puedes cambiar la configuración de la aplicación a través del archivo application_settings.txt.

La estructura del archivo de configuración es la siguiente:

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

## requisitos
* Unity 6000.0.31f1 (IL2CPP)

## licencia
* El código está licenciado bajo la [Licencia Apache 2.0](LICENSE).
* Los siguientes activos están licenciados bajo [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/).
  * BGM
  * Modelos

## Sobre los materiales
* Las animaciones de personajes predeterminadas se crean utilizando [“VRMお人形遊び”用アニメーションデータ詰め合わせ](https://fumi2kick.booth.pm/items/1655686). Se ha confirmado que se pueden distribuir incluidas en el repositorio.
* La fuente utilizada es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Se redistribuye la fuente Noto Sans JP bajo la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Los derechos de autor de la fuente pertenecen al autor original (Google).
* La voz predeterminada utiliza sonidos de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Se ha confirmado la forma de uso con COEIROINK de antemano.
* Los iconos de los botones se realizan utilizando [MingCute](https://github.com/MidraLab/MingCute).

## Créditos de los creadores
* Modelos: 「アオゾラ」様
* BGM: MidraLab (eisuke)
* Icono del software: やむちゃ様

## Avisos de terceros

Consulta [NOTICE](./NOTICE.md).

## patrocinador
- Luna
- uezo