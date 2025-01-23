# uDesktopMascot

[![Versión de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Lanzamientos](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: Los idiomas arriba mencionados (English, 中文, Español, Français) han sido generados mediante traducción automática por GPT-4o-mini. Para precisión y matices de la traducción, por favor consulta el texto original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Resumen](#resumen)
  * [Lista de características](#lista-de-características)
  * [Requisitos](#requisitos)
  * [Licencia](#licencia)
  * [Sobre los materiales](#sobre-los-materiales)
  * [Créditos de los creadores](#créditos-de-los-creadores)
  * [Avisos de terceros](#avisos-de-terceros)
  * [Patrocinador](#patrocinador)
<!-- TOC -->

## Resumen

"uDesktopMascot" es un proyecto de código abierto que muestra personajes en el escritorio y reproduce reacciones y sonidos en respuesta a la interacción del usuario. Este proyecto ha sido desarrollado utilizando Unity y soporta personajes en formato VRM, permitiendo disfrutar de tus personajes favoritos en el escritorio de manera sencilla.

**Plataformas compatibles**
* Windows 10/11
* macOS

## Lista de características

La aplicación incluye las siguientes funciones. Para más detalles, consulta la lista a continuación.

La adición de activos externos se puede realizar colocando los archivos en la carpeta StreamingAssets.

<details>

<summary>Modelos y animaciones</summary>
* Carga y muestra archivos de modelos ubicados en StreamingAssets.
  * Soporta modelos en formato VRM (1.x, 0.x).
  * Soporta modelos en formato GLB/GLTF.

</details>

<details>

<summary>Voz y BGM</summary>
* Carga y reproduce archivos de audio ubicados en SteamingAssets/Voice/. Si hay múltiples archivos, se reproducirán aleatoriamente.
  * Los sonidos que se reproducen al hacer clic se cargan desde archivos de audio ubicados en StreamingAssets/Voice/Click/.
* Carga y reproduce archivos de música ubicados en SteamingAssets/BGM/. Si hay múltiples archivos, se reproducirán aleatoriamente.
* Adición de la voz predeterminada del personaje
  * La voz predeterminada utiliza el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproducirá al iniciar la aplicación, al cerrarla y al hacer clic.

</details>

<details>

<summary>Configuración de la aplicación a través de archivos de texto</summary>
Puedes cambiar la configuración de la aplicación mediante el archivo application_settings.txt.

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

## Requisitos
* Unity 6000.0.31f1(IL2CPP)

## Licencia
* El código está licenciado bajo la [Licencia Apache 2.0](LICENSE).
* Los siguientes activos están licenciados bajo [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/):
  * BGM
  * Modelos

## Sobre los materiales
* Las animaciones del personaje predeterminado se han creado utilizando el [Conjunto de datos de animación para "VRMお人形遊び"](https://fumi2kick.booth.pm/items/1655686). Esto se ha verificado para su distribución incluida en el repositorio.
* La fuente utilizada es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Se redistribuye bajo la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Los derechos de autor de la fuente pertenecen al autor original (Google).
* La voz predeterminada se utiliza a partir del audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Este uso ha sido previamente confirmado con COEIROINK.
* El icono del botón utiliza [MingCute](https://github.com/MidraLab/MingCute).

## Créditos de los creadores
* Modelo: "アオゾラ"
* BGM: MidraLab(eisuke)
* Icono de software: やむちゃ

## Avisos de terceros

Consulta [NOTICE](./NOTICE.md).

## Patrocinador
- Luna
- uezo