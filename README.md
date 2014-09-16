# TESTGAME-README: Installation and specifications

## Contents

* **Introduction**

* **About The Game**

* **Installation**

* **Folder and File Specifications**

* **TODO**

## Introduction

VersusUnityGame is a test game to be run with the Versus API written in
the Unity Framework with C#.

## About The Game

- Modes Planned:
  1. Single player bullethell style (http://www.youtube.com/watch?v=utGmwWVq-ck)
    - points awarded for fighters killed
    - won't be as cool as the video
  2. Synchronous multiplayer mode
    - each person controls a fighter
    - 2-4 players battle in an arena
    - last man standing wins

## Installation

1. Download and install Unity (if not already installed)
  - https://unity3d.com/unity/download
2. Clone git repo
3. Open Assets/testgame.unity

## Folder and File Specifications

- `Assets/testgame.unity` main unity file to be opened by Unity editor

- `Assets/Scripts/` scripts that testgame.unity uses

  - `Assets/Scripts/Characters/` scripts that pertain to characters in the game

    - `Assets/Scripts/Characters/CharacterConstants.cs` character stats (i.e. speed, health, etc)

    - `Assets/Scripts/Characters/Fighter.cs` generic fighter character

    - `Assets/Scripts/Characters/FighterFactory.cs` factory for creating new fighter objects of different type

  - `Assets/Scripts/Game/` scripts that pertain to running the game

    - `Assets/Scripts/Game/GameController.cs` in charge of game

    - `Assets/Scripts/Game/GameMaster.cs` in charge of application (will rename to ApplicationController.cs)

    - `Assets/Scripts/Game/InputController.cs` in charge of player input

  - `Assets/Scripts/Versus/` scripts that pertain to communicating with versus API


## TODO

* **EVERYTHING**

* **Definitely not in working condition**

