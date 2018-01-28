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

	public override void Cancel()
	{
		base.Cancel();
		var connectedCollider = gameObject.GetComponent<Collider>();
		if (connectedCollider != null)
		{
			connectedCollider.enabled = false; 
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		if (!this.enabled) return;
		
		if ( ReactToLayer == (ReactToLayer | (1 << other.gameObject.layer))){
			var damageReceiver = other.GetComponent<HealthData>();
			if (damageReceiver != null)
			{
				float rest = Data.FlatDamage;
				while (damageReceiver.ArmorItems.Count>0 && rest > 0)
				{
					var armor = damageReceiver.ArmorItems.Pop();
					armor.ArmorValue -= rest;
					rest = 0;
					if (armor.ArmorValue <= 0)
					{
						rest += Mathf.Abs(armor.ArmorValue);
						armor.gameObject.SetActive(false);
					}
					else
					{
						damageReceiver.ArmorItems.Push(armor);
					}

				}
				damageReceiver.CurrentHealth -= rest;
				damageReceiver.LastDamageDealer = this;
			}
			if (DisablesAfterHit)
			{
				this.enabled = false;
			}
		}
		
	}
}
