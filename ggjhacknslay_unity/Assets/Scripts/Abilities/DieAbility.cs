﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class DieAbility : Ability
{
	private HealthData Data;
	private DeadData DeadData;
	public Ability[] ActivateOnDeath; 
	
	[Inject]
	void Init ()
	{
		Data = gameObject.GetComponent<HealthData>();
	}

	private void Update()
	{
		if (Data.CurrentHealth < 0 && DeadData == null)
		{
			var abilities = gameObject.GetComponents<Ability>();
			var childAbilities = gameObject.GetComponentsInChildren<Ability>();
			var parentBehaviours = gameObject.GetComponentsInParent<Behaviour>();
			foreach (var ability in abilities)
			{
				ability.enabled = ability.ResistsDeath;
			}
			foreach (var ability in childAbilities)
			{
				ability.enabled = ability.ResistsDeath;
			}
			foreach (var behaviour in parentBehaviours)
			{
				behaviour.DeactivateBehaviour();
			}
			DeadData = gameObject.AddComponent<DeadData>();
			foreach (var ability in ActivateOnDeath)
			{
				ability.Activate();
			}
			
		}
	}
}
