﻿//Programmed by Alan Thorn 2015
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class PlayerController : MonoBehaviour
{
	//------------------------------
	private Rigidbody ThisBody = null;
//	private Transform ThisTransform = null;
	
	public bool MouseLook = true;
	public string HorzAxis = "Horizontal";
	public string VertAxis = "Vertical";
	public string FireAxis = "Fire1";

	public float MaxSpeed = 5f;
	public float rotationSpeed = 0.5f;

	public float reloadDelay = 0.3f;
	public bool canFire = true;

	public Transform[] turretTransforms;

	//------------------------------
	// Use this for initialization
	void Awake ()
	{
		ThisBody = GetComponent<Rigidbody>();
//		ThisTransform = GetComponent<Transform>();
	}
	//------------------------------
	// Update is called once per frame
	void FixedUpdate ()
	{
		//Update movement
		float Horz = Input.GetAxis(HorzAxis);
		float Vert = Input.GetAxis(VertAxis);
		Vector3 MoveDirection = new Vector3(Horz, 0.0f, Vert);
		ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);
		
		//Clamp speed
		ThisBody.velocity = new Vector3(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
		                                Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed),
		                                Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed));
		
		//Should look with mouse?
		if(MouseLook)
		{
			//Update rotation - turn to face mouse pointer
			Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
			MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);
			
			//Get direction to cursor
			Vector3 LookDirection = MousePosWorld - transform.position;
			Quaternion LookRotation = Quaternion.LookRotation (LookDirection);
			
			//FixedUpdate rotation
			transform.rotation = Quaternion.RotateTowards (transform.rotation, LookRotation, rotationSpeed);
		}

		//Weapon Control
		if(Input.GetButton(FireAxis)&&canFire)
		{
			foreach (Transform T  in turretTransforms)
				AmmoManager.SpawnAmmo (T.position, T.rotation);
			
			canFire = false;
			Invoke ("EnableFire", reloadDelay);
		}
	}

	void EnableFire()
	{
		canFire = true;
	}

	public void Die()
	{
		GameController.GameOver ();
		Destroy (gameObject);
	}
}
//------------------------------