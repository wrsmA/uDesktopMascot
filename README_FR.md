# uDesktopMascot

[![Unity Version](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) sont générées par une traduction automatique de GPT-4o-mini. Pour la précision et les nuances de la traduction, veuillez vous référer au texte original (日本語).

<!-- TOC -->
* [uDesktopMascot](#udesktopmascot)
  * [Aperçu](#aperçu)
  * [Liste des fonctionnalités](#liste-des-fonctionnalités)
  * [exigences](#exigences)
  * [licence](#licence)
  * [À propos des matériels](#à-propos-des-matériaux)
  * [Crédits des créateurs](#crédits-des-créateurs)
  * [Avis de tiers](#avis-de-tiers)
<!-- TOC -->

## Aperçu

"uDesktopMascot" est un projet open source qui affiche des personnages sur le bureau et réagit aux interactions des utilisateurs grâce à des réactions et des sons. Ce projet est développé avec Unity et prend en charge les personnages au format VRM, ce qui vous permet de profiter facilement de vos personnages préférés sur votre bureau.

## Liste des fonctionnalités

L'application comprend les fonctionnalités suivantes. Veuillez vous référer à la liste ci-dessous pour plus de détails.

<details>

<summary>Liste des fonctionnalités</summary>

* Charge et affiche des fichiers VRM placés dans StreamingAssets. En cas de plusieurs fichiers, le premier trouvé sera chargé. Compatible avec VRM 0.x et VRM 1.x.
* Charge et joue des fichiers audio placés dans SteamingAssets/Voice/. En cas de plusieurs fichiers, ceux-ci seront joués au hasard.
  * Les sons joués lors d'un clic sont chargés et joués à partir des fichiers audio placés dans StreamingAssets/Voice/Click/. 
* Charge et joue des fichiers musicaux placés dans SteamingAssets/BGM/. En cas de plusieurs fichiers, ceux-ci seront joués au hasard.
* Ajout de la voix par défaut du personnage
  * La voix par défaut utilise les sons de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Elle est jouée au lancement de l'application, à la fermeture de l'application et lors des clics.

</details>

## exigences
* Unity 6000.0.31f1(IL2CPP)

## licence
* Le code est sous licence [Apache License 2.0](LICENSE).
* Les actifs suivants sont sous licence [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) :
  * BGM
  * Modèle
  * Animation

## À propos des matériels
* Les animations par défaut des personnages sont créées en utilisant [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La police est [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). La redistribution de la police Noto Sans JP est conforme à la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur original (Google).
* La voix par défaut utilise les sons de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). L'utilisation a été préalablement confirmée auprès de COEIROINK.

## Crédits des créateurs
* Modèle : « Aozora »
* BGM : MidraLab (eisuke)

## Avis de tiers

Voir [NOTICE](./NOTICE.md).