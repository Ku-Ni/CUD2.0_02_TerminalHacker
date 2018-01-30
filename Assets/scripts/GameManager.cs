using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private GameState gameState;
    private PasswordManager passwordManager;
    private DisplayManager displayManager;
    private int currentLevel = 0;


    [SerializeField] int charactersWide = 60;
    [SerializeField] int charactersHigh = 20;


    // Use this for initialization
    void Start() {
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

    internal int GetDisplayWidth() {
        return charactersWide;
    }

    internal int GetDisplayHeight() {
        return charactersHigh;
    }

    private void LoadNextLevel() {
        Debug.Log("Loading level " + ++currentLevel);
        List<string> passwords = passwordManager.GetPasswords("ASTRONOMY", currentLevel);
        displayManager.ClearScreen();
        displayManager.LoadPasswords(passwords);
    }
}
