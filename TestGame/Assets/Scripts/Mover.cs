using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	public float selfDestructTime;
	private float lifeTime;

	void Start () 
	{
		lifeTime = Time.time;
	}
	
	void Update () 
	{
		Vector3 movePosition = Vector3.left * speed * Time.deltaTime;
		transform.position +=movePosition;

		if (Time.time - lifeTime >= selfDestructTime)
			DestroyImmediate (this.gameObject);
	}
}
