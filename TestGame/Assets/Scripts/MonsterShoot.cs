using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour {

	public Transform shootSpawn;
	public float shootdelay;
	public GameObject projectile;
	public AudioSource shootSound;

	private Animator animCon;
	private float lastShootTime;

	void Start () 
	{
		lastShootTime = Time.time;
		animCon = GetComponentInChildren<Animator>();
	}
	

	void Update () 
	{
		if (Time.time - lastShootTime >= shootdelay) 
		{	
			animCon.SetTrigger ("Shot");
			Instantiate (projectile, shootSpawn.transform.position, shootSpawn.transform.rotation);
			shootSound.Play ();
			lastShootTime = Time.time;
		}
	}
}
