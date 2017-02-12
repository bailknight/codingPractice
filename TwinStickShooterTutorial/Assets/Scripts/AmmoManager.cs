//Programmed by Alan Thorn 2015

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmmoManager : MonoBehaviour
{
	//Reference to ammo prefab
	public GameObject ammoPrefab = null;

	//Ammo pool count
	public int poolSize = 100;

	public Queue<Transform> ammoQueue = new Queue<Transform>();

	//Array of ammo objects to generate
	private GameObject[] ammoArray;

	public static AmmoManager ammoManagerSingleton = null;

	// Use this for initialization
	void Awake ()
	{
		if(ammoManagerSingleton != null)
		{
			Destroy(GetComponent<AmmoManager>());
			return;
		}

		ammoManagerSingleton = this;
		ammoArray = new GameObject[poolSize];

		for(int i=0; i<poolSize; i++)
		{
			ammoArray[i] = Instantiate(ammoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			Transform ObjTransform = ammoArray[i].GetComponent<Transform>();
			ObjTransform.parent = GetComponent<Transform>();
			ammoQueue.Enqueue(ObjTransform);
			ammoArray[i].SetActive(false);
		}
	}

	public static Transform SpawnAmmo(Vector3 position, Quaternion rotation)
	{
		//Get ammo
		Transform spawnedAmmo = ammoManagerSingleton.ammoQueue.Dequeue();

		spawnedAmmo.gameObject.SetActive(true);
		spawnedAmmo.position = position;
		spawnedAmmo.localRotation = rotation;

		//Add to queue end
		ammoManagerSingleton.ammoQueue.Enqueue(spawnedAmmo);

		//Return ammo
		return spawnedAmmo;
	}

}
