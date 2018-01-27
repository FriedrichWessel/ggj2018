using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplyFlatDamageAbility : DamageAbility
{
	public bool DisablesAfterHit = true;
	public LayerMask ReactToLayer; 
	
	[Inject]
	private void Init()
	{
		this.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!this.enabled) return;
		
		if ( ReactToLayer == (ReactToLayer | (1 << other.gameObject.layer))){
			var damageReceiver = other.GetComponent<HealthData>();
			if (damageReceiver != null)
			{
				damageReceiver.CurrentHealth -= Data.FlatDamage;
			}
			if (DisablesAfterHit)
			{
				this.enabled = false;
			}
		}
		
	}
}
