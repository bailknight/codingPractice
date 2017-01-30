using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : MonoBehaviour 
{
	public Text scoreLabel;
	public Text coinLabel;
	//public Text highscoreLabel;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (GameManager.instance.currentGameState == Gamestate.gameOver) 
		{
			scoreLabel.text = PlayerController.instance.GetDistance().ToString ("f0");
			coinLabel.text = GameManager.instance.collectedCoins.ToString ();
			//highscoreLabel.text = PlayerPrefs.GetFloat ("highscore", 0).ToString ("f0");
		}
	}
}
