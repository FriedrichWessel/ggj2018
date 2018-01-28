using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderArmorUIAbility : Ability
{

	public Slider Healthbar;
	public HealthData Data;

	public void Start()
	{
		Healthbar.maxValue = 20;
		Healthbar.minValue = 0;
	}

	private void OnDisable()
	{
		Healthbar.enabled = false; 
	}

	void Update()
	{
		Healthbar.value = Data.ArmorValue;
	}
}
