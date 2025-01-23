# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: Los idiomas mencionados arriba (English, 中文, Español, Français) han sido generados mediante traducción automática con GPT-4o-mini. Para precisión y matices en la traducción, consulte el texto original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Resumen](#resumen)
  * [Lista de Funciones](#lista-de-funciones)
  * [Requisitos](#requisitos)
  * [Licencia](#licencia)
  * [Acerca de los Materiales](#acerca-de-los-materiales)
  * [Créditos de Creadores](#créditos-de-creadores)
  * [Avisos de Terceros](#avisos-de-terceros)
  * [Patrocinador](#patrocinador)
<!-- TOC -->

## Resumen

"uDesktopMascot" es un proyecto de código abierto que muestra personajes en el escritorio y reproduce reacciones y sonidos en función de la interacción del usuario. Este proyecto se ha desarrollado utilizando Unity y soporta personajes en formato VRM, lo que le permite disfrutar fácilmente de sus personajes favoritos en el escritorio.

**Plataformas compatibles**
* Windows 10/11
* macOS

## Lista de Funciones

La aplicación implementa las siguientes funciones. Para más detalles, consulte la lista a continuación.

La adición de activos externos se puede realizar colocando archivos en la carpeta StreamingAssets.

<details>

<summary>Modelos y Animaciones</summary>
* Se pueden cargar y mostrar archivos de modelo personalizados colocados en StreamingAssets.
  * Se admiten modelos en formato VRM(1.x, 0.x).
  * Se admiten modelos en formato GLB/GLTF.

</details>

<details>

<summary>Voz y BGM</summary>
* Se cargan y reproducen archivos de audio colocados en StreamingAssets/Voice/. Si hay varios, se reproducirán de forma aleatoria.
  * Los sonidos que se reproducen al hacer clic se cargan desde archivos de audio colocados en StreamingAssets/Voice/Click/. 
* Se cargan y reproducen archivos de música colocados en StreamingAssets/BGM/. Si hay varios, se reproducirán de forma aleatoria.
* Agregar voz por defecto para los personajes
  * La voz por defecto utiliza audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproduce al iniciar la aplicación, al cerrarla y al hacer clic.

</details>

<details>

<summary>Configuración de Aplicaciones a través de Archivos de Texto</summary>
El archivo application_settings.txt permite modificar la configuración de la aplicación.

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

## Acerca de los Materiales
* Las animaciones de los personajes predeterminados fueron creadas utilizando el [“Paquete de Datos de Animación para 'VRMお人形遊び'”](https://fumi2kick.booth.pm/items/1655686). Se ha confirmado la distribución de estos en el repositorio.
* La fuente es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Se redistribuye la fuente Noto Sans JP según la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Los derechos de autor de la fuente son del autor original (Google).
* La voz predeterminada utiliza audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Se ha confirmado previamente el uso con COEIROINK.
* Los íconos de los botones utilizan [MingCute](https://github.com/MidraLab/MingCute).

## Créditos de Creadores
* Modelos: "アオゾラ"様
* BGM: MidraLab(eisuke)
* Iconos de software: やむちゃ様

## Avisos de Terceros

Ver [NOTICE](./NOTICE.md).

## Patrocinador
- Luna
- uezo