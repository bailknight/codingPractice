using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			PlayerController.instance.Attacked();
            Debug.Log("It`s a Trap!");
        }
    }
}
