﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class ReceiveMouseTargetAbility : Ability {
	private NewWalkTargetSignal _walkTargetSignal;

	public GoalAbility[] TargetAbilities;
	
	// Use this for initialization
	[Inject]
	public void Init (NewWalkTargetSignal walkTargetSignal)
	{
		_walkTargetSignal = walkTargetSignal;
		_walkTargetSignal += SetTarget;
	}
	
	private void OnDestroy()
	{
		_walkTargetSignal -= SetTarget;
	}

	private void SetTarget(Vector3 targetPos)
	{
		if (!this.enabled) return;
		
		foreach (var targetAbility in TargetAbilities)
		{
				targetAbility.SetTarget(targetPos);
		}
	}
	
	
}
