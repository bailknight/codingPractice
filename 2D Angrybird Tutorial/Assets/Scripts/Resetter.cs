using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {

	public Rigidbody2D projectile;
	public float resetSpeed = 0.025f;

	private float resetSpeedSqr;
	private SpringJoint2D spring;

	void Start () {
		spring = projectile.GetComponent <SpringJoint2D> ();
		projectile = projectile.GetComponent <Rigidbody2D> ();
		resetSpeedSqr = resetSpeed * resetSpeed;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
		{
			Reset ();
		}

		if(spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr)
		{
			Reset ();
		}
	}

	void OnTriggerExit2D(Collider2D other)
		{
		if (other.attachedRigidbody == projectile)
			Reset ();
		}

	void Reset()
	{
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}
}
