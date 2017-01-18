using UnityEngine;
using System.Collections;

public class LearningReusableMethods : MonoBehaviour {

    public int number1 = 2;
    public int number2 = 3;
    public int number3 = 7;

	// Use this for initialization
	void Start () {
        AddAndPrintTwoNumbers(number1, number2);
        AddAndPrintTwoNumbers(number1, number3);
        AddAndPrintTwoNumbers(number2, number3);

	}
	
	// Update is called once per frame
	int AddAndPrintTwoNumbers (int firstNumber,int secondNumber) {
        int result = firstNumber + secondNumber;
        return result;
	}
}
