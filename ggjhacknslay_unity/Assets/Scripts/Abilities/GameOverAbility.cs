using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameOverAbility : Ability {
	private GameOverSignal _gameOverSignal;

	[Inject]
	private void Init(GameOverSignal gameOverSignal)
	{
		_gameOverSignal = gameOverSignal; 
	}

	public override void Activate()
	{
		base.Activate();
		_gameOverSignal.Fire();
	}
}
