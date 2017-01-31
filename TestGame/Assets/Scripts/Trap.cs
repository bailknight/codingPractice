using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    void Start()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), PlayerController.instance.GetComponentInChildren<BoxCollider2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FloorDetector")
        {
            Debug.Log("FloorContact");
            return;
        }
        if (other.tag == "Player")
        {
			PlayerController.instance.Attacked();
            Debug.Log("It`s a Trap!");
        }
    }
}
