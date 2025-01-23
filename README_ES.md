# uDesktopMascot

[![Versión de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Lanzamientos](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: Los idiomas mencionados anteriormente (English, 中文, Español, Français) han sido generados mediante traducción automática por GPT-4o-mini. Para precisión y matices de traducción, por favor consulte el texto original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Resumen](#resumen)
  * [Lista de características](#lista-de-características)
  * [requisitos](#requisitos)
  * [licencia](#licencia)
  * [Sobre los materiales](#sobre-los-materiales)
  * [Créditos de los creadores](#créditos-de-los-creadores)
  * [Avisos de terceros](#avisos-de-terceros)
  * [patrocinador](#patrocinador)
<!-- TOC -->

## Resumen

“uDesktopMascot” es un proyecto de código abierto que muestra personajes en el escritorio y reproduce reacciones y sonidos en función de la interacción del usuario. Este proyecto ha sido desarrollado utilizando Unity y admite personajes en formato VRM, lo que permite disfrutar de sus personajes favoritos en el escritorio de manera sencilla.

**Plataformas compatibles**
* Windows 10/11
* macOS

## Lista de características

La aplicación ha implementado las siguientes funciones. Consulte la lista a continuación para más detalles.

La adición de activos externos se puede lograr colocando los archivos en la carpeta StreamingAssets.

<details>

<summary>Modelo y animación</summary>
* Carga y visualiza archivos de modelo en la carpeta StreamingAssets.
  * Admite modelos en formato VRM (1.x, 0.x).
  * Admite modelos en formato GLB/GLTF.

</details>

<details>

<summary>Voces y BGM</summary>
* Carga y reproduce archivos de audio en la carpeta SteamingAssets/Voice/. Si hay varios, se reproducen aleatoriamente.
  * Los sonidos reproducidos al hacer clic se cargan desde la carpeta StreamingAssets/Voice/Click/. 
* Carga y reproduce archivos de música en la carpeta StreamingAssets/BGM/. Si hay varios, se reproducen aleatoriamente.
* Adición de la voz predeterminada del personaje
  * La voz predeterminada utiliza audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproduce al iniciar y cerrar la aplicación, y al hacer clic.

</details>

<details>

<summary>Configuración de la aplicación mediante archivo de texto</summary>
Se pueden modificar las configuraciones de la aplicación mediante el archivo application_settings.txt.

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
* Unity 6000.0.31f1(IL2CPP)

## licencia
* El código está licenciado bajo la [Licencia Apache 2.0](LICENSE).
* Los siguientes activos están licenciados bajo [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/).
  * BGM
  * Modelos

## Sobre los materiales
* Las animaciones predeterminadas del personaje se crearon utilizando [“Animaciones para el juego de muñecas VRM”](https://fumi2kick.booth.pm/items/1655686). Se ha confirmado la distribución de estos en el repositorio.
* La fuente utilizada es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Se redistribuye la fuente Noto Sans JP bajo [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). El copyright de la fuente pertenece al autor original (Google).
* La voz predeterminada se utiliza con el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Se ha confirmado el uso previamente con COEIROINK.
* Los íconos de botones utilizan [MingCute](https://github.com/MidraLab/MingCute).

## Créditos de los creadores
* Modelo: “アオゾラ” 
* BGM: MidraLab(eisuke)
* Icono del software: やむちゃ

## Avisos de terceros

Consulte [NOTICE](./NOTICE.md).

## patrocinador
- Luna
- uezo