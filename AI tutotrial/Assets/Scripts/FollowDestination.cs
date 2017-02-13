using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowDestination : MonoBehaviour {

	private NavMeshAgent thisAgent = null;
	public Transform destination = null;


	void Awake () 
	{
		thisAgent = GetComponent<NavMeshAgent> ();
	}
	

	void Update () 
	{
		thisAgent.SetDestination (destination.position);
	}
}
