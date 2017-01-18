using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LearningLoopsSearching : MonoBehaviour {

    public List<string> familyMembers = new List<string>();

	// Use this for initialization
	void Start () {
        familyMembers.Add("Greg");
        familyMembers.Add("Kate");
        familyMembers.Add("Adam");
        familyMembers.Add("Mia");

        int adamsIndex = -1;

        for(int i = 0; i < familyMembers.Count; i++)
        {
            if (familyMembers[i] == "Adam")
            {
                adamsIndex = i;
                break;
            }
        }
        if (adamsIndex == -1)
        {
            Debug.Log("No Adam in list");
        }
        else
            Debug.Log("Adam`s index number is " + adamsIndex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
