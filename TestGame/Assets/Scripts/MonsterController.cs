using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

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
            Debug.Log("Monster Attack!");
        }
    }

	public void Hurt()
	{
		Destroy (this.gameObject);
	}
}
