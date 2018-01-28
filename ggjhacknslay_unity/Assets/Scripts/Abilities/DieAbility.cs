using System;
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
	private TaskSystem _taskSystem;

	[Inject]
	void Init (TaskSystem taskSystem)
	{
		Data = gameObject.GetComponent<HealthData>();
		_taskSystem = taskSystem; 
	}

	private void Update()
	{
		if (Data.CurrentHealth <= 0 && DeadData == null)
		{
			var abilities = gameObject.GetComponents<Ability>();
			var childAbilities = gameObject.GetComponentsInChildren<Ability>();
			var parentBehaviours = gameObject.GetComponentsInParent<Behaviour>();
			foreach (var ability in abilities)
			{
				if (!ability.ResistsDeath)
				{
					ability.enabled = false; 
					ability.Cancel();
				}
			}
			foreach (var ability in childAbilities)
			{
				if (!ability.ResistsDeath)
				{
					ability.enabled = false; 
					ability.Cancel();
				}
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
			_taskSystem.StopAll(this.gameObject);
		}
	}
}
