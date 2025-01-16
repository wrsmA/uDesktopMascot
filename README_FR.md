# uDesktopMascot

[![Version Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) ont été générées par une traduction automatique avec GPT-4o-mini. Pour la précision et les nuances de la traduction, veuillez vous référer au texte original (日本語).

## Résumé

« uDesktopMascot » est un projet open source qui affiche des personnages sur le bureau et joue des réactions et des sons en fonction des interactions des utilisateurs. Ce projet est développé à l'aide de Unity et prend en charge les personnages au format VRM, ce qui vous permet de profiter facilement de vos personnages préférés sur votre bureau.

## Fonctionnalités
* Charge et affiche des fichiers VRM placés dans le dossier StreamingAssets. S'il y en a plusieurs, le premier trouvé sera chargé.
* Charge et joue des fichiers audio placés dans SteamingAssets/Voice/. S'il y en a plusieurs, ils seront joués de manière aléatoire.
  * Les sons joués lors d'un clic sont chargés à partir des fichiers audio placés dans StreamingAssets/Voice/Click/.
* Charge et joue des fichiers musicaux placés dans SteamingAssets/BGM/. S'il y en a plusieurs, ils seront joués de manière aléatoire.
* Ajout d'une voix par défaut pour le personnage
  * La voix par défaut utilise l'audio de [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Elle se joue au lancement de l'application, à la fermeture de l'application et lors d'un clic.

# Exigences
* Unity 6000.0.31f1 (IL2CPP)

# Licence
* Le code est licencié sous la [Licence Apache 2.0](LICENSE).
* Les ressources suivantes sont sous la licence [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) :
  * BGM
  * Modèles
  * Animations

# Matériel
* L'animation par défaut du personnage est créée à l'aide de [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La police utilisée est [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Elle est redistribuée sous la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur original (Google).
* La voix par défaut est celle de [COEIROINK: Tsukuyomi-chan](https://coeiroink.com/character/audio-character/tsukuyomi-chan). J'ai préalablement vérifié les modalités d'utilisation avec COEIROINK.

# Crédits des créateurs
* Modèle : « Aozora »
* BGM : MidraLab (eisuke)