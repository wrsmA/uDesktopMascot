# uDesktopMascot

[![Versión de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Lanzamientos](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Nota**: Los idiomas mencionados anteriormente (English, 中文, Español, Français) han sido generados mediante traducción automática de GPT-4o-mini. Para la precisión y matices de la traducción, se recomienda consultar el texto original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Resumen](#resumen)
  * [Lista de características](#lista-de-características)
  * [requisitos](#requisitos)
  * [licencia](#licencia)
  * [Sobre los materiales](#sobre-los-materiales)
  * [Créditos del creador](#créditos-del-creador)
  * [Avisos de terceros](#avisos-de-terceros)
  * [patrocinador](#patrocinador)
<!-- TOC -->

## Resumen

"uDesktopMascot" es un proyecto de código abierto que muestra personajes en el escritorio y reproduce reacciones y voces en función de la interacción del usuario. Este proyecto ha sido desarrollado utilizando Unity y soporta personajes en formato VRM, permitiéndote disfrutar fácilmente de tus personajes favoritos en el escritorio.

**Plataformas compatibles**
* Windows 10/11
* macOS

## Lista de características

La aplicación incluye las siguientes funciones. Consulta la lista a continuación para más detalles.

La adición de activos externos se puede lograr colocando archivos en la carpeta StreamingAssets.

<details>

<summary>Modelos y animaciones</summary>
* Carga y muestra archivos de modelos colocados en StreamingAssets.
  * Admite modelos en formato VRM (1.x, 0.x).
  * Admite modelos en formato GLB/GLTF.

</details>

<details>

<summary>Voz y BGM</summary>
* Carga y reproduce archivos de audio colocados en StreamingAssets/Voice/. Si hay varios, se reproducirán de manera aleatoria.
  * La voz que se reproduce al hacer clic se carga desde archivos de audio ubicados en StreamingAssets/Voice/Click/. 
* Carga y reproduce archivos de música colocados en StreamingAssets/BGM/. Si hay varios, se reproducirán de manera aleatoria.
* Adición de la voz predeterminada del personaje
  * La voz predeterminada utiliza el audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Se reproduce al iniciar la aplicación, al cerrarla y al hacer clic.

</details>

<details>

<summary>Configuración de la aplicación mediante archivo de texto</summary>
Puedes modificar la configuración de la aplicación mediante el archivo application_settings.txt.

La estructura del archivo de configuración es la siguiente:

```txt
[Character]
ModelPath=default.vrm
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
* La animación predeterminada del personaje se ha creado utilizando [“Paquete de datos de animación para VRM ひな形”](https://fumi2kick.booth.pm/items/1655686). Se ha confirmado que puede distribuirse junto con el repositorio.
* La fuente es [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Se redistribuye bajo la [Licencia SIL OPEN FONT Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Los derechos de autor de la fuente pertenecen al autor original (Google).
* La voz predeterminada se utiliza del audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Se ha confirmado el uso con COEIROINK de antemano.
* El ícono de botones utiliza [MingCute](https://github.com/MidraLab/MingCute).

## Créditos del creador
* Modelos: 「アオゾラ」様
* BGM: MidraLab (eisuke)
* Icono de software: やむちゃ様

## Avisos de terceros

Consulta [NOTICE](./NOTICE.md).

## patrocinador
- Luna
- uezo