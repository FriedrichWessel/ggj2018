using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WalkToTargetTask : Task  {
	private TargetableAbility _target;
	private WalkTowardsGoalAbility _source;

	public WalkToTargetTask(WalkTowardsGoalAbility source, TargetableAbility target, object owner) : base(owner)
	{
		_target = target;
		_source = source;
	}

	public override void Tick()
	{
		_source.SetTarget(_target.transform.position);
		if (_source.DistanceToTarget < _target.Radius)
		{
			StopTask();
		}
		
	}

	public override void Cancel()
	{
		StopTask();
	}

	private void StopTask()
	{
		_source.CancelWalk();
		FireFinished();
		base.Cancel();
	}
}
