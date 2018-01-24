using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private readonly string logo = @"
===========================================================
     _       __           __       __                __
    | |     / ____ ______/ /____  / ____ _____  ____/ /
    | | /| / / __ `/ ___/ __/ _ \/ / __ `/ __ \/ __  /
    | |/ |/ / /_/ (__  / /_/  __/ / /_/ / / / / /_/ /
    |__/|__/\__,_/____/\__/\___/_/\__,_/_/ /_/\__,_/

                __  __           __
               / / / ____ ______/ /_____  _____
              / /_/ / __ `/ ___/ //_/ _ \/ ___/
             / __  / /_/ / /__/ ,< /  __/ /
            /_/ /_/\__,_/\___/_/|_|\___/_/

===========================================================

press any key to start...
";
    private GameState gameState;
    private PasswordManager passwordManager;

    public enum GameState {
        START_MENU, GAME_ON, FINISH
    }

	// Use this for initialization
	void Start () {
        passwordManager = GameObject.FindObjectOfType<PasswordManager>();
        LoadMainMenu();
	}

    private void LoadMainMenu() {
        gameState = GameState.START_MENU;
        Terminal.WriteLine(logo);
    }

    internal GameState GetGameState() {
        return gameState;
    }
    
    internal void StartGame() {
        throw new NotImplementedException();
    }
}
