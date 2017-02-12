//Programmed by Alan Thorn 2015
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class ProxyDamage : MonoBehaviour
{
	//------------------------------
	//Damage per second
	public float DamageRate = 20f;
	public float impactPower = 5f;
	//------------------------------
	void OnTriggerStay(Collider Col)
	{
		Vector3 colPosition = Col.transform.position;
		Vector3 pushDirection = colPosition - transform.position;
		Health H = Col.gameObject.GetComponent<Health>();

		if(H == null)return;

		H.HealthPoints -= DamageRate * Time.deltaTime;
		Col.attachedRigidbody.AddForce (pushDirection.normalized*impactPower, ForceMode.Impulse);
	}
	//------------------------------
}
//------------------------------