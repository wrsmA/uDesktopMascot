# uDesktopMascot

[![Version Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) ont été générées par une traduction automatique par GPT-4o-mini. Pour la précision et les nuances de la traduction, veuillez vous référer au texte original (日本語).

## Résumé

« uDesktopMascot » est un projet open source qui affiche un personnage sur le bureau et joue des réactions ou des sons en fonction des interactions de l'utilisateur. Ce projet est développé en utilisant Unity et prend en charge les personnages au format VRM, ce qui vous permet de profiter facilement de votre personnage préféré sur votre bureau.

## Fonctionnalités
* Affiche des fichiers VRM placés dans StreamingAssets. S'il y en a plusieurs, celui en tête de liste sera chargé.
* Charge et joue des fichiers audio placés dans SteamingAssets/Voice/. S'il y en a plusieurs, ils seront joués au hasard.
  * Les sons joués lors d'un clic sont chargés à partir des fichiers audio placés dans StreamingAssets/Voice/Click/.
* Charge et joue des fichiers musicaux placés dans SteamingAssets/BGM/. S'il y en a plusieurs, ils seront joués au hasard.
* Ajout de la voix par défaut du personnage.
  * La voix par défaut utilise l'audio de [COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Elle sera jouée au démarrage de l'application, à la fermeture de l'application et lors des clics.

# Exigences
* Unity 6000.0.31f1 (IL2CPP)

# Licence
* Le code est sous licence [Apache License 2.0](LICENSE).
* Les actifs suivants sont sous licence [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) :
  * BGM
  * Modèles
  * Animations

# À propos des ressources
* Les animations de personnage par défaut sont créées à l'aide de [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La police utilisée est [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Elle est redistribuée sous la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur original (Google).
* La voix par défaut utilise l'audio de [COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). J'ai vérifié à l'avance auprès de COEIROINK pour son utilisation.

# Crédits des auteurs
* Modèle : « Aozora » 
* BGM : MidraLab (eisuke)