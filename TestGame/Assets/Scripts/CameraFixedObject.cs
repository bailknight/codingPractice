using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixedObject : MonoBehaviour {

	public Transform targetCamera;

	private Vector3 newPosition;



	void Start () 
	{
		
	}

	void Update () 
	{
		float offset = targetCamera.transform.position.x - transform.position.x;
		newPosition = new Vector3 (transform.position.x + offset, transform.position.y, transform.position.z);
		transform.position = newPosition;
	}
}
