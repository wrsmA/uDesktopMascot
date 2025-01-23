# uDesktopMascot

[![Version Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) ont été générées par une traduction automatique à l'aide de GPT-4o-mini. Pour la précision et les nuances de la traduction, veuillez consulter le texte original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Aperçu](#aperçu)
  * [Liste des fonctionnalités](#liste-des-fonctionnalités)
  * [exigences](#exigences)
  * [licence](#licence)
  * [À propos des matériaux](#à-propos-des-matériaux)
  * [Crédits des créateurs](#crédits-des-créateurs)
  * [Avis de tiers](#avis-de-tiers)
  * [sponsor](#sponsor)
<!-- TOC -->

## Aperçu

« uDesktopMascot » est un projet open source qui affiche des personnages sur le bureau et rejoue des réactions et des sons en fonction des interactions de l'utilisateur. Ce projet est développé à l'aide de Unity et prend en charge les personnages au format VRM, ce qui permet de profiter facilement de ses personnages préférés sur le bureau.

**Plateformes prises en charge**
* Windows 10/11
* macOS

## Liste des fonctionnalités

L'application intègre les fonctionnalités suivantes. Pour plus de détails, veuillez consulter la liste ci-dessous.

L'ajout de ressources externes peut être réalisé en plaçant des fichiers dans le dossier StreamingAssets.

<details>

<summary>Modèles et animations</summary>
* Charge et affiche les fichiers de modèle à partir de StreamingAssets.
  * Prend en charge les modèles aux formats VRM (1.x, 0.x).
  * Prend en charge les modèles aux formats GLB/GLTF.

</details>

<details>

<summary>Voix et BGM</summary>
* Charge et joue les fichiers audio placés dans SteamingAssets/Voice/. S'il y en a plusieurs, ils seront joués au hasard.
  * Les sons qui se jouent lors d'un clic sont chargés à partir des fichiers audio placés dans StreamingAssets/Voice/Click/. 
* Charge et joue les fichiers musicaux placés dans SteamingAssets/BGM/. S'il y en a plusieurs, ils seront joués au hasard.
* Ajout d'une voix par défaut pour le personnage.
  * La voix par défaut utilise les sons de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Elle sera jouée au démarrage de l'application, à la fermeture de l'application et lors des clics.

</details>

<details>

<summary>Configuration de l'application par fichier texte</summary>
Vous pouvez modifier les paramètres de l'application grâce à un fichier application_settings.txt.

La structure du fichier de configuration est la suivante :

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

## exigences
* Unity 6000.0.31f1(IL2CPP)

## licence
* Le code est sous licence [Apache License 2.0](LICENSE).
* Les ressources suivantes sont sous licence [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) :
  * BGM
  * Modèle

## À propos des matériaux
* Les animations par défaut du personnage sont créées à partir du [pack de données d’animation pour 'VRMお人形遊び'](https://fumi2kick.booth.pm/items/1655686). Cela a été confirmé pour être distribué avec le dépôt.
* La police utilisée est [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Elle est redistribuée sous [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur original (Google).
* La voix par défaut utilise les sons de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). La façon de l'utiliser a été confirmée à l'avance avec COEIROINK.
* Les icônes des boutons utilisent [MingCute](https://github.com/MidraLab/MingCute).

## Crédits des créateurs
* Modèle : « アオゾラ »様
* BGM : MidraLab(eisuke)
* Icône du logiciel : やむちゃ様

## Avis de tiers

Voir [NOTICE](./NOTICE.md).

## sponsor
- Luna
- uezo