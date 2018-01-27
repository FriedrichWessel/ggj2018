using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackZoneBehaviour : Behaviour {
	private TaskSystem _taskSystem;

	public Collider AttackZone;
	public TargetedAttackAbility AttackAbility;
	public LayerMask ReactTo; 

	[Inject]
	private void Init(TaskSystem taskSystem)
	{
		_taskSystem = new TaskSystem();
	}

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
