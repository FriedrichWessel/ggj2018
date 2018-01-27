using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackZoneBehaviour : Behaviour {

	public Collider AttackZone;
	public TargetedAttackAbility AttackAbility;
	public LayerMask ReactTo; 

	
	private void OnTriggerEnter(Collider other)
	{
		if ( ReactTo == (ReactTo | (1 << other.gameObject.layer))){
			Attack(other);
		}
	}

	public override void Activate()
	{
		
		AttackZone.enabled = true;
	}

	public override void DeactivateBehaviour()
	{
		AttackAbility.Cancel();
		AttackZone.enabled = false;
		base.DeactivateBehaviour();
	}

	private void Attack(Collider other)
	{
		var target = other.GetComponent<TargetableAbility>();
		if (target != null)
		{
			AttackAbility.Deactivated += DeactivateBehaviour; 
			AttackAbility.Attack(target);
		}
	}
}
