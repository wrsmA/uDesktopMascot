# uDesktopMascot

[![Version Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) ont été générées par traduction automatique avec GPT-4o-mini. Pour la précision et les nuances de la traduction, veuillez vous référer au texte original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Aperçu](#aperçu)
  * [Liste des fonctionnalités](#liste-des-fonctionnalités)
  * [exigences](#exigences)
  * [licence](#licence)
  * [À propos du matériel](#à-propos-du-matériel)
  * [Crédits des créateurs](#crédits-des-créateurs)
  * [Avis des tiers](#avis-des-tiers)
  * [sponsor](#sponsor)
<!-- TOC -->

## Aperçu

« uDesktopMascot » est un projet open source qui affiche un personnage sur le bureau et reproduit des réactions et des sons en fonction des interactions de l'utilisateur. Ce projet est développé en utilisant Unity et prend en charge les personnages au format VRM, vous permettant de profiter facilement de votre personnage préféré sur votre bureau.

**Plateformes prises en charge**
* Windows 10/11
* macOS

## Liste des fonctionnalités

L'application possède les fonctionnalités suivantes. Veuillez consulter la liste ci-dessous pour plus de détails.

L'ajout d'actifs externes peut être réalisé en les plaçant dans le dossier StreamingAssets.

<details>

<summary>Modèles et animations</summary>
* Charge et affiche les fichiers modèles placés dans StreamingAssets.
  * Prend en charge les modèles au format VRM (1.x, 0.x).
  * Prend en charge les modèles au format GLB/GLTF.

</details>

<details>

<summary>Voix et BGM</summary>
* Charge et reproduit les fichiers audio placés sous SteamingAssets/Voice/. S'il y en a plusieurs, ils seront joués aléatoirement.
  * Les sons joués lors d'un clic sont chargeés depuis les fichiers audio placés dans StreamingAssets/Voice/Click/.
* Charge et reproduit les fichiers de musique placés sous SteamingAssets/BGM/. S'il y en a plusieurs, ils seront joués aléatoirement.
* Ajout de la voix par défaut du personnage
  * La voix par défaut utilise l’audio de [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Elle est jouée au démarrage de l'application, à la fermeture de l'application et lors des clics.

</details>

<details>

<summary>Configuration de l'application via un fichier texte</summary>
Le fichier application_settings.txt permet de modifier les paramètres de l'application.

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
* Les actifs suivants sont sous licence [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) :
  * BGM
  * Modèles

## À propos du matériel
* Les animations par défaut du personnage sont créées à partir de l' [ensemble de données d'animation pour "VRM Oningyou Asobi"](https://fumi2kick.booth.pm/items/1655686). Leur distribution avec le dépôt a été vérifiée.
* La police utilisée est [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). La redistribution de la police Noto Sans JP est faite sous [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur original (Google).
* La voix par défaut est issue de l’audio de [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Son utilisation a été confirmée auprès de COEIROINK au préalable.
* L'icône du bouton est issue de [MingCute](https://github.com/MidraLab/MingCute).

## Crédits des créateurs
* Modèle : « Aozora »
* BGM : MidraLab (eisuke)
* Icône du logiciel : Yamucha

## Avis des tiers

Voir [NOTICE](./NOTICE.md).

## sponsor
- Luna
- uezo