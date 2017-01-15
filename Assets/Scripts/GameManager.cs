using UnityEngine;
using System.Collections;

public enum Gamestate
{
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour {

    public Gamestate currentGameState = Gamestate.menu;
    public static GameManager instance;

    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentGameState = Gamestate.menu;
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        PlayerController.instance.StartGame();
        SetGameState(Gamestate.inGame);
    }

    public void GameOver()
    {
        SetGameState(Gamestate.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(Gamestate.menu);
    }

void SetGameState(Gamestate newGameState)
    {
        if (newGameState == Gamestate.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == Gamestate.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == Gamestate.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }
        currentGameState = newGameState;
    }

    
}
