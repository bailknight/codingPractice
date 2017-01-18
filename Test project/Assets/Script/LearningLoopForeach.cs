using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LearningLoopForeach : MonoBehaviour {

    public List<string> familyMembers = new List<string>();
	// Use this for initialization
	void Start () {
        familyMembers.Add("Greg");
        familyMembers.Add("Kate");
        familyMembers.Add("Adam");
        familyMembers.Add("Mia");

        foreach(string familyMember in familyMembers)
        {
            Debug.Log(familyMember);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
