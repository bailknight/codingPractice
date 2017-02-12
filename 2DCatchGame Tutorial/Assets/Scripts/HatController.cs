using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour {

	public Camera cam;

	private Rigidbody2D rb2D;
	private float maxWidth;
	private Renderer rdr;
	private bool canControl;

	void Start () 
	{
		rdr = GetComponent<Renderer> ();
		rb2D = GetComponent <Rigidbody2D> ();
		if (cam == null)
		{
			cam = Camera.main;			
		}
		canControl = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float hatWidth = rdr.bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;
	}
	

	void FixedUpdate () 
	{
		if (canControl) 
		{
			Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Vector3 targetPosition = new Vector3 (rawPosition.x, 0f, 0f);
			float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
			targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
			rb2D.MovePosition (targetPosition);
		}

	}

	public void ToggleControl(bool toggle)
	{
		canControl = toggle;
	}
}
