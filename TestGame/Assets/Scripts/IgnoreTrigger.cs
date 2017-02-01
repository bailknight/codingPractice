using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTrigger : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), PlayerController.instance.GetComponentInChildren<BoxCollider2D>());
    }
}
