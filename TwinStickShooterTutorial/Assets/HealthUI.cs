using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	public Slider hpSlider;


	public void UpdateSlider (float hp) 
	{
		hpSlider.value = hp;
	}
}
