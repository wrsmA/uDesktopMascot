# uDesktopMascot

[![Version Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Versions](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) sont générées par un système de traduction automatique GPT-4o-mini. Pour la précision ou les nuances de la traduction, veuillez vous référer au texte original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Aperçu](#aperçu)
  * [Liste des fonctionnalités](#liste-des-fonctionnalités)
  * [Exigences](#exigences)
  * [Licence](#licence)
  * [À propos des ressources](#à-propos-des-ressources)
  * [Crédits des créateurs](#crédits-des-créateurs)
  * [Avis de tiers](#avis-de-tiers)
  * [Sponsor](#sponsor)
<!-- TOC -->

## Aperçu

« uDesktopMascot » est un projet open source qui affiche des personnages sur le bureau et joue des réactions et des sons en fonction de l'interaction de l'utilisateur. Ce projet est développé avec Unity et prend en charge les personnages au format VRM, permettant ainsi de profiter facilement de vos personnages préférés sur le bureau.

**Plateformes prises en charge**
* Windows 10/11
* macOS

## Liste des fonctionnalités

L'application implémente les fonctionnalités suivantes. Pour plus de détails, veuillez consulter la liste ci-dessous.

L'ajout d'actifs externes peut être réalisé en les plaçant dans le dossier StreamingAssets.

<details>

<summary>Modèles et animations</summary>
* Charge et affiche les fichiers de modèle placés dans StreamingAssets.
  * Prend en charge les modèles au format VRM(1.x, 0.x).
  * Prend en charge les modèles au format GLB/GLTF.

</details>

<details>

<summary>Voix et musique de fond</summary>
* Charge et joue les fichiers audio placés dans SteamingAssets/Voice/. S'il y en a plusieurs, ils seront joués aléatoirement.
  * Les sons joués lors des clics sont chargés à partir des fichiers audio placés dans StreamingAssets/Voice/Click/.
* Charge et joue les fichiers musicaux placés dans SteamingAssets/BGM/. S'il y en a plusieurs, ils seront joués aléatoirement.
* Ajout de la voix par défaut du personnage
  * La voix par défaut utilise les sons de [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Elle est jouée au démarrage de l'application, à la fermeture de l'application et lors des clics.

</details>

<details>

<summary>Configuration de l'application via fichier texte</summary>
Il est possible de modifier les paramètres de l'application via le fichier application_settings.txt.

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

## Exigences
* Unity 6000.0.31f1(IL2CPP)

## Licence
* Le code est sous [Apache License 2.0](LICENSE).
* Les actifs suivants sont sous [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) :
  * BGM
  * Modèles

## À propos des ressources
* Les animations par défaut du personnage sont créées avec [les données d'animation pour 'VRM Doll Play'](https://fumi2kick.booth.pm/items/1655686). La distribution de celles-ci dans le dépôt a été vérifiée.
* La police utilisée est le [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Cette police est redistribuée sous [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur original (Google).
* La voix par défaut utilise les sons de [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan). L'utilisation a été préalablement vérifiée auprès de COEIROINK.
* Les icônes de boutons proviennent de [MingCute](https://github.com/MidraLab/MingCute).

## Crédits des créateurs
* Modèle : « Aozora »
* BGM : MidraLab (eisuke)
* Icône du logiciel : Yamucha

## Avis de tiers

Voir [NOTICE](./NOTICE.md).

## Sponsor
- Luna
- uezo