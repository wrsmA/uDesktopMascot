# uDesktopMascot

[![Version Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) ont été générées par une traduction automatique effectuée par GPT-4o-mini. Pour la précision et les nuances de la traduction, veuillez vous référer au texte source (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Présentation](#présentation)
  * [Liste des fonctionnalités](#liste-des-fonctionnalités)
  * [Exigences](#exigences)
  * [Licence](#licence)
  * [À propos des matériaux](#à-propos-des-matériaux)
  * [Crédits des créateurs](#crédits-des-créateurs)
  * [Avis de tiers](#avis-de-tiers)
  * [Sponsor](#sponsor)
<!-- TOC -->

## Présentation

« uDesktopMascot » est un projet open source qui affiche un personnage sur le bureau et joue des réactions et des sons en fonction des interactions de l'utilisateur. Ce projet est développé avec Unity et prend en charge les personnages au format VRM, permettant ainsi à l'utilisateur de profiter facilement de son personnage préféré sur le bureau.

**Plateformes prises en charge**
* Windows 10/11
* macOS

## Liste des fonctionnalités

L'application contient les fonctionnalités suivantes. Pour plus de détails, veuillez vous référer à la liste ci-dessous.

L'ajout d'actifs externes peut être réalisé en les plaçant dans le dossier StreamingAssets.

<details>

<summary>Modèles et animations</summary>
* Charge et affiche un fichier de modèle placé dans StreamingAssets.
  * Prend en charge les modèles au format VRM (1.x, 0.x).
  * Prend en charge les modèles au format GLB/GLTF.

</details>

<details>

<summary>Voix et BGM</summary>
* Charge et joue des fichiers audio placés dans SteamingAssets/Voice/. S'il y en a plusieurs, ils seront joués au hasard.
  * Les fichiers audio joués lors d'un clic sont chargés depuis StreamingAssets/Voice/Click/.
* Charge et joue des fichiers musicaux placés dans SteamingAssets/BGM/. S'il y en a plusieurs, ils seront joués au hasard.
* Ajout de voix par défaut pour le personnage
  * La voix par défaut utilise des échantillons audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Joue lors du démarrage de l'application, de sa fermeture et lors d'un clic.

</details>

<details>

<summary>Paramètres de l'application par fichier texte</summary>
Il est possible de modifier les paramètres de l'application via le fichier application_settings.txt.

La structure du fichier de paramètres est la suivante :

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

## Exigences
* Unity 6000.0.31f1(IL2CPP)

## Licence
* Le code est sous [Apache License 2.0](LICENSE).
* Les actifs suivants sont sous licence [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) :
  * BGM
  * Modèles

## À propos des matériaux
* Les animations par défaut du personnage sont créées à l'aide de [l'ensemble de données d'animations pour "VRMお人形遊び"](https://fumi2kick.booth.pm/items/1655686). Cette distribution a été vérifiée pour sa conformité à la distribution dans le référentiel.
* La police utilisée est [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). La police Noto Sans JP est redistribuée sous [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur d'origine (Google).
* La voix par défaut utilise des échantillons audio de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Son utilisation a été préalablement confirmée auprès de COEIROINK.
* Les icônes des boutons proviennent de [MingCute](https://github.com/MidraLab/MingCute).

## Crédits des créateurs
* Modèle : « アオゾラ »
* BGM : MidraLab (eisuke)
* Icône du logiciel : やむちゃ

## Avis de tiers

Voir [NOTICE](./NOTICE.md).

## Sponsor
- Luna
- uezo