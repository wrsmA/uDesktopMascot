# uDesktopMascot

[![Version Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Versions](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) ont été générées par une traduction automatique avec GPT-4o-mini. Pour l'exactitude et les nuances des traductions, veuillez vous référer au texte original (日本語).

## Résumé

« uDesktopMascot » est un projet open source qui affiche un personnage sur votre bureau et joue des réactions et des sons en fonction de l'interaction de l'utilisateur. Ce projet est développé avec Unity et prend en charge des personnages au format VRM, ce qui vous permet de profiter facilement de vos personnages préférés sur votre bureau.

## Caractéristiques
* Chargement et affichage de fichiers VRM placés dans StreamingAssets. En cas de plusieurs fichiers, celui au début de la liste sera chargé.
* Chargement et lecture des fichiers audio placés dans SteamingAssets/Voice/. En cas de plusieurs fichiers, ils seront joués de manière aléatoire.
  * Le son joué lors d'un clic est chargé depuis les fichiers audio placés dans StreamingAssets/Voice/Click/. 
* Chargement et lecture des fichiers musicaux placés dans SteamingAssets/BGM/. En cas de plusieurs fichiers, ils seront joués de manière aléatoire.
* Ajout de la voix par défaut du personnage.
  * La voix par défaut utilise les sons de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Elle sera jouée au démarrage de l'application, à la fermeture de l'application et lors d'un clic.

# exigences
* Unity 6000.0.31f1(IL2CPP)

# licence
* Le code est sous licence [Apache License 2.0](LICENSE).
* Les actifs suivants sont sous licence [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/) :
  * BGM
  * Modèles
  * Animations

# À propos des matériaux
* Les animations par défaut des personnages sont créées avec [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La police utilisée est [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Elle est redistribuée selon la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur original (Google).
* La voix par défaut utilise les sons de [COEIROINK: つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). L'utilisation a été préalablement vérifiée auprès de COEIROINK.

# Crédits des créateurs
* Modèle : « Aozora »
* BGM : MidraLab (eisuke)