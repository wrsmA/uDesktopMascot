# uDesktopMascot

[![Version de Unity](https://img.shields.io/badge/Unity-6000.0%2B-blueviolet?logo=unity)](https://unity.com/releases/editor/archive)
[![Releases](https://img.shields.io/github/release/MidraLab/uDesktopMascot.svg)](https://github.com/MidraLab/uDesktopMascot/releases)

日本語 | [English](README_EN.md) | [中文](README_CN.md) | [Español](README_ES.md) | [Français](README_FR.md)

**Remarque** : Les langues ci-dessus (English, 中文, Español, Français) ont été générées par traduction automatique avec GPT-4o-mini. Pour la précision et les nuances de la traduction, veuillez vous référer au texte original (日本語).

## Aperçu

« uDesktopMascot » est un projet open source qui affiche des personnages sur le bureau et joue des réactions et des voix en fonction des interactions de l'utilisateur. Ce projet est développé en utilisant Unity et prend en charge les personnages au format VRM, ce qui permet de profiter facilement de vos personnages préférés sur votre bureau.

## Caractéristiques
* Charge et affiche n'importe quel fichier VRM placé dans le dossier StreamingAssets. En cas de plusieurs fichiers, il charge le premier trouvé.
* Charge et joue des fichiers audio placés dans le dossier SteamingAssets/Voice. En cas de plusieurs fichiers, ils sont joués aléatoirement.
  * Les audio jouées au moment des clics proviennent de fichiers audio placés dans StreamingAssets/Voice/Click/.
* Charge et joue des fichiers de musique placés dans le dossier SteamingAssets/BGM. En cas de plusieurs fichiers, ils sont joués aléatoirement.
* Ajout d'une voix par défaut au personnage
  * La voix par défaut utilise l'audio de [COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan).
  * Elle est jouée au démarrage de l'application, à la fermeture de l'application et au moment des clics.

# Exigences
* Unity 6000.0.31f1 (IL2CPP)

# À propos des ressources
* Les animations par défaut des personnages sont créées à l'aide de [Unity Muse Animate](https://muse.unity.com/ja-jp/explore).
* La musique de fond par défaut a été créée comme un asset au sein de MidraLab.
* La police utilisée est [Noto Sans Japanese](https://fonts.google.com/noto/specimen/Noto+Sans+JP?lang=ja_Jpan). Nous répartissons la police Noto Sans JP selon la [SIL OPEN FONT LICENSE Version 1.1](https://fonts.google.com/noto/specimen/Noto+Sans+JP/license?lang=ja_Jpan). Les droits d'auteur de la police appartiennent à l'auteur original (Google).
* La voix par défaut utilise l'audio de [COEIROINK:つくよみちゃん](https://coeiroink.com/character/audio-character/tsukuyomi-chan). Nous avons préalablement vérifié avec COEIROINK pour les modalités d'utilisation.