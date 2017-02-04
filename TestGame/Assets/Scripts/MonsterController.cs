using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

	private Animator animCon;
	public float removeWait;
	private Collider2D col;

	void Start()
	{
		col = GetComponent<Collider2D>();
		animCon = GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag != "Player")
        {
            Debug.Log("IgnoreContact");
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
		col.enabled = false;
		animCon.SetTrigger ("Death");
		Invoke ("Remove", removeWait);
		SoundManager.instance.MonsterDeathClip ();
	}

	void Remove()
	{
		Destroy (this.gameObject);
	}
}
