//Programmed by Alan Thorn 2015
//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class Spawner : MonoBehaviour
{
	public float maxRadius = 1f;
	public float interval = 5f;
	public float minSpawnDistance = 2f;
	public GameObject objToSpawn = null;
	private Transform origin = null;
	//------------------------------
	void Awake()
	{
		origin = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	//------------------------------
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("Spawn", 0f, interval);
	}
	//------------------------------
	void Spawn () 
	{
		if(origin == null)return;

		Vector3 spawnPos = origin.position + Random.onUnitSphere * maxRadius;
		spawnPos.y = 0f;
		Vector3 dirToObject = origin.position - spawnPos;
		Vector3 safeSpawnPos = spawnPos - dirToObject.normalized*minSpawnDistance;
		Quaternion spawnRot = Quaternion.LookRotation (dirToObject);
		spawnPos = new Vector3(safeSpawnPos.x, 0f, safeSpawnPos.z);
		Instantiate(objToSpawn, safeSpawnPos, spawnRot);
	}
	//------------------------------
}
//------------------------------