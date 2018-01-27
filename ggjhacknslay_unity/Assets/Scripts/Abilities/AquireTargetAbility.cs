using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AquireTargetAbility : Ability {
	private TargetAquiredSignal _targetAquireSignal;
	public TargetedAttackAbility Ability;

	[Inject]
	private void Init(TargetAquiredSignal aquireSignal)
	{
		_targetAquireSignal = aquireSignal;
		_targetAquireSignal += Ability.Attack;

	}

	private void OnDestroy()
	{
		_targetAquireSignal -= Ability.Attack;
	}
}
