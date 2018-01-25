using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private GameState gameState;
    private PasswordManager passwordManager;
    private DisplayManager displayManager;
    private int currentLevel = 0;

    public enum GameState {
        START_MENU, GAME_ON, FINISH
    }

	// Use this for initialization
	void Start () {
        passwordManager = GameObject.FindObjectOfType<PasswordManager>();
        displayManager = GameObject.FindObjectOfType<DisplayManager>();
        LoadMainMenu();
	}

    private void LoadMainMenu() {
        gameState = GameState.START_MENU;
        displayManager.LoadMainMenu();
    }

    internal GameState GetGameState() {
        return gameState;
    }
    
    internal void StartGame() {
        gameState = GameState.GAME_ON;
        LoadNextLevel();
    }

    private void LoadNextLevel() {
        List<string> passwords = passwordManager.GetPasswords("theme", currentLevel++);
        displayManager.ClearScreen();
        displayManager.LoadPasswords(passwords);
    }
}
