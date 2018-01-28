using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAbilityTask : Task {
	private Ability _ability;
	private bool _running = false; 
	public ActivateAbilityTask(Ability ability, object owner ) : base(owner)
	{
		_ability = ability;
	}

	public override void Tick()
	{
		if (_running)
		{
			return;
		}
		_running = true;
		_ability.Deactivated += FireFinished;
		if (_ability.enabled)
		{
			_ability.Activate();
		}
	}

	public override void Cancel()
	{
		_ability.Cancel();
		_ability.Deactivated -= FireFinished;
		_running = false;
	}
}
