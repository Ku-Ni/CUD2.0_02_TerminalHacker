using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnUserInput(string input) {
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
