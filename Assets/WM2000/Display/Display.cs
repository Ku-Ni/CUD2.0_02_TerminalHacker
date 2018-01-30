using System;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {
    private GameManager gameManager;

    [SerializeField] Terminal connectedToTerminal;

    [SerializeField] Text fullText;
    [SerializeField] Text hintText;
    [SerializeField] Text inputText;

    private void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        WarnIfTerminalNotConneced();
    }


    private void WarnIfTerminalNotConneced() {
        if (!connectedToTerminal) {
            Debug.LogWarning("Display not connected to a terminal");
        }
    }


    // Akin to monitor refresh
    private void Update() {
        if (!connectedToTerminal)
            throw new UnityException("No terminal connected to Display!");

        ClearScreen();

        GameState currentGameState = gameManager.GetGameState();
        switch (currentGameState) {
            case GameState.START_MENU:
                fullText.text = connectedToTerminal.GetMenuDisplayText();
                break;
            case GameState.GAME_ON:
                // game text
                hintText.text = connectedToTerminal.GetPasswordHintDisplayText();
                inputText.text = connectedToTerminal.GetInputDisplayBuffer(gameManager.GetDisplayWidth(), gameManager.GetDisplayHeight());
               
                break;
            case GameState.FINISH:
                fullText.text = connectedToTerminal.GetInputDisplayBuffer(gameManager.GetDisplayWidth(), gameManager.GetDisplayHeight());
                // end text
                break;
            default:
                Debug.LogError("Invalid GameState: " + currentGameState);
                throw new UnityException("Invalid GameState: " + currentGameState);
        }
    }

    private void ClearScreen() {
        fullText.text = "";
        hintText.text = "";
        inputText.text = "";
    }
}