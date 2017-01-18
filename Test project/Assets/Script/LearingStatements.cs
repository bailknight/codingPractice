using UnityEngine;
using System.Collections;

public class LearingStatements : MonoBehaviour
{
    public int speedlimit = 60;
    // Use this for initialization
    void Start()
    {
        if(speedlimit > 70)
        {
            Debug.Log("Over Speed");

        }
        else if (speedlimit <= 70 && speedlimit >= 30)
        {
            Debug.Log("speed limit is less than 70 and more or equals to 30");
        }
        else if (speedlimit < 30)
        {
            Debug.Log("speed is 30 or less");
        }
    }
}