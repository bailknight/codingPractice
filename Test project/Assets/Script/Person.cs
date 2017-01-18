using UnityEngine;
using System.Collections;

public class Person {

    public string firstname = "";
    public string lastname = "";
    public Person spouse;

    public Person()
    {

    }

    public Person(string pFirstName, string pLastName)
    {
        this.firstname = pFirstName;
        this.lastname = pLastName;
    }
    public bool IsMarriedWith (Person otherPerson)
    {

        if(spouse != null)
        {
            if(otherPerson == this.spouse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
