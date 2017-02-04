using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {

	public string firstText;
	public string secondText;
	public float changeTime;
	public Text label;

	void Start () 
	{
		label.text = firstText;
		Invoke ("ChangeText", changeTime);
	}

	void ChangeText()
	{
		label.text = secondText;
	}

	void OnDisable()
	{
		label.text = firstText;
	}

	void OnEnable()
	{
		Invoke ("ChangeText", changeTime);
	}
}
