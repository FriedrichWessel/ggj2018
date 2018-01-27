using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplyFlatDamageAbility : Ability
{
	private DamageData Data;

	[Inject]
	private void Init()
	{
		Data = gameObject.GetComponent<DamageData>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!this.enabled) return;
		
		var damageReceiver = other.GetComponent<HealthData>();
		if (damageReceiver != null)
		{
			damageReceiver.Health -= Data.FlatDamage;
		}
	}
}
