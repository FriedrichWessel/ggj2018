using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

public class TargetedAttackAbility : Ability {
	
	private TaskSystem _taskSystem;

	public WalkTowardsGoalAbility WalkAbility;
	public ActiveAttackData ActiveAttack;
	private TargetAquiredSignal _targetAquiredSignal;

	[Inject]
	public void Init(TaskSystem taskSystem, TargetAquiredSignal signal)
	{
		_taskSystem = taskSystem;
		_targetAquiredSignal = signal;
		_targetAquiredSignal += Attack;
	}

	private void OnDestroy()
	{
		_targetAquiredSignal -= Attack;
	}

	public void Attack(TargetableAbility target)
	{
		_taskSystem.StopAll();
		var walkTask = new WalkToTargetTask(WalkAbility, target);
		var attackTask = new ActivateAbilityTask(ActiveAttack.Attack);
		_taskSystem.EnqueueTask(walkTask);
		_taskSystem.EnqueueTask(attackTask);
	}
}
