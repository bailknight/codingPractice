using UnityEngine;
using System.Collections;

public class LearningObjects : MonoBehaviour {

    public Person man;
    public Person woman;
    public Person woman2;

    // Use this for initialization
    void Start () {

        man = new Person("Greg","Lukosek");

        woman = new Person("Kate","Lukosek");

        woman2 = new Person("Kyung Lim", "Kim");


        man.spouse = woman2;
        woman.spouse = man;
        woman2.spouse = man;

        if (man.IsMarriedWith(woman2))
        {
            Debug.Log(man.firstname + " is married to " + woman2.firstname);
        }
        else
        {
            Debug.Log(man.firstname + " and "+woman2.firstname + " are not married");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
