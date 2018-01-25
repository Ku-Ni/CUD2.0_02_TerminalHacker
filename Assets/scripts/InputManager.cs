using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager: MonoBehaviour {

    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // runs after enter is pressed
    void OnUserInput(string input) {
        Debug.Log("OnUserInput:" + input);
        switch (gameManager.GetGameState()) {
            case GameManager.GameState.START_MENU:
                gameManager.StartGame();
                break;
            case GameManager.GameState.GAME_ON:
                break;
            case GameManager.GameState.FINISH:
                break;
            default:
                throw new UnityException("Invalid GameState: " + gameManager.GetGameState());
        }
    }
}
