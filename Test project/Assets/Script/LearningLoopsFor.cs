using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LearningLoopsFor : MonoBehaviour {

    public List<string> familyMembers = new List<string>();

	// Use this for initialization
	void Start () {
        familyMembers.Add("Greg");
        familyMembers.Add("Kate");
        familyMembers.Add("Adam");
        familyMembers.Add("Mia");

        for(int i = 0; i < familyMembers.Count; i++)
        {
            Debug.Log(familyMembers[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
