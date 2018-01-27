using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

public class TargetedAttackAbility : Ability {
	
	private TaskSystem _taskSystem;

	public WalkTowardsGoalAbility WalkAbility;
	public ActiveAttackData ActiveAttack;

	[Inject]
	public void Init(TaskSystem taskSystem)
	{
		_taskSystem = taskSystem;
	}

	public void Attack(TargetableAbility target)
	{
		_taskSystem.StopAll(this);
		var walkTask = new WalkToTargetTask(WalkAbility, target,this);
		var attackTask = new ActivateAbilityTask(ActiveAttack.Attack, this);
		_taskSystem.EnqueueTask(walkTask);
		_taskSystem.EnqueueTask(attackTask);
	}

	public override void Cancel()
	{
		_taskSystem.StopAll(this);
	}
}
