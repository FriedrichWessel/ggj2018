using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplyFlatDamageAbility : DamageAbility
{
	public bool DisablesAfterHit = true;
	[Inject]
	private void Init()
	{
		this.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!this.enabled) return;
		
		var damageReceiver = other.GetComponent<HealthData>();
		if (damageReceiver != null)
		{
			damageReceiver.Health -= Data.FlatDamage;
		}
		if (DisablesAfterHit)
		{
			this.enabled = false;
		}
	}
}
