using UnityEngine;
using System.Collections;

public class LearningReusableMethodsWithReturn : MonoBehaviour {
    public int number1 = 2;
    public int number2 = 3;


	// Use this for initialization
	void Start () {
        int sumResult = AddTwoNumbers(number1, number2);
        DisplayResult(sumResult);
    
	}

    int AddTwoNumbers(int firstnumber, int secoundnumber)
    {
        int result = firstnumber + secoundnumber;
        return result;
    }


	void DisplayResult (int total) {
        Debug.Log("The grand total is:" + total);
	}
}
