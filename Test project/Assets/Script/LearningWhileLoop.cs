using UnityEngine;
using System.Collections;

public class LearningWhileLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int i = 0;
        while (i < 10)
        {
            Debug.Log(i);
            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
