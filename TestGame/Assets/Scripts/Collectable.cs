using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	int score = 10;
//	bool isCollected = false;

    void Show()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
//        isCollected = false;
    }

    void Hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }

    void Collect()
    {
//        isCollected = true;
        Hide();
		SoundManager.instance.PlayCoinClip ();
		GameManager.instance.CollectedCoin ();
		PlayerController.instance.CollectiblePoint (score);
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Collect();
        }
    }
}