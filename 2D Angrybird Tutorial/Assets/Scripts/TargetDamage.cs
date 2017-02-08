using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour {

	public int hitPoints = 2;
	public Sprite damagedSprite;
	public float damageImpactSpeed;

	private int currentHitPoints;
	private float damageImpactSpeedSqr;
	private SpriteRenderer spriteRenderer;
	private Collider2D col2D;
	private Rigidbody2D rb2D;
	private ParticleSystem deathParticle;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		col2D = GetComponent <Collider2D> ();
		rb2D = GetComponent <Rigidbody2D> ();
		deathParticle = GetComponentInChildren <ParticleSystem> ();
		currentHitPoints = hitPoints;
		damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag != "Damager")
			return;
		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
			return;

		spriteRenderer.sprite = damagedSprite;
		currentHitPoints--;

		if (currentHitPoints <= 0)
			Kill ();
	}

	void Kill()
	{
		spriteRenderer.enabled = false;
		col2D.enabled = false;
		rb2D.isKinematic = true;
		deathParticle.Play ();

	}
}
