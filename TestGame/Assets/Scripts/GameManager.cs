using UnityEngine;
using System.Collections;

public enum Gamestate
{
	wait,
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour {

    public Gamestate currentGameState = Gamestate.menu;
    public static GameManager instance;
	public CameraFollow m_cameraFollow;
	public float startWait;
    [HideInInspector] public int collectedCoins = 0;

    public Canvas menuCanvas;
	public GameObject inGameCanvas;
    public Canvas gameOverCanvas;
	public GameObject waitCanvas;

	private LevelGenerator levelGenerator;

    void Awake()
    {
        instance = this;
		levelGenerator = GetComponent <LevelGenerator>();
    }

    void Start()
    {
        currentGameState = Gamestate.menu;
		levelGenerator.GenerateInitialPieces ();
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
		StartCoroutine (StartGameWait());
    }
 

	public IEnumerator StartGameWait()
	{
		collectedCoins = 0;
		SetGameState(Gamestate.wait);
		PlayerController.instance.StartGame();
		levelGenerator.Restart ();
		m_cameraFollow.RestartPosition ();
		yield return new WaitForSeconds (startWait);
		PlayerController.instance.isAlive = true;
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
			inGameCanvas.SetActive(false);
            gameOverCanvas.enabled = false;
			waitCanvas.SetActive(false);
        }
        else if (newGameState == Gamestate.inGame)
        {
            menuCanvas.enabled = false;
			inGameCanvas.SetActive(true);
            gameOverCanvas.enabled = false;
			waitCanvas.SetActive(false);
			SoundManager.instance.PlayBGM ();
        }
        else if (newGameState == Gamestate.gameOver)
        {
            menuCanvas.enabled = false;
			inGameCanvas.SetActive(false);
            gameOverCanvas.enabled = true;
			waitCanvas.SetActive(false);
			SoundManager.instance.MuteBGM ();
        }
		else if (newGameState == Gamestate.wait)
		{
			menuCanvas.enabled = false;
			inGameCanvas.SetActive(false);
			gameOverCanvas.enabled = false;
			waitCanvas.SetActive(true);
		}
        currentGameState = newGameState;
    }

	public void CollectedCoin()
	{
		collectedCoins++;
	}
}
