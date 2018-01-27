using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderHealthUIAbility : Ability
{

	public Slider Healthbar;
	public HealthData Data;

	public void Start()
	{
		Healthbar.maxValue = Data.BaseHealth;
		Healthbar.minValue = 0;
	}

	private void OnDisable()
	{
		Healthbar.enabled = false; 
	}

	void Update()
	{
		Healthbar.value = Data.CurrentHealth;
	}
}
