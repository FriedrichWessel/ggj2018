using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IngameUIPresenter : MonoBehaviour {
	private GameStartSignal _gameStartSignal;
	private GameOverSignal _gameOverSignal;

	public Animator Animator;
	public RenderHealthUIAbility EnemyHealthRenderer; 
	
	private TargetAquiredSignal _targetAquiredSignal;

	[Inject]
	private void Init(
		GameStartSignal startSignal,
		GameOverSignal gameOverSignal, 
		TargetAquiredSignal targetAquiredSignal
		)
	{
		_targetAquiredSignal = targetAquiredSignal;
		_gameStartSignal = startSignal;
		_gameOverSignal = gameOverSignal;
		_gameStartSignal += ShowUI;
		_gameOverSignal += HideUI;
		_targetAquiredSignal += UpdateEnemyHealthData;

	}

	private void UpdateEnemyHealthData(TargetableAbility obj)
	{
		var healthData = obj.GetComponent<HealthData>();
		if (healthData != null)
		{
			EnemyHealthRenderer.Data = healthData;
		}
	}

	void OnDestroy()
	{
		_gameStartSignal -= ShowUI;
		_gameOverSignal -= HideUI; 
		_targetAquiredSignal -= UpdateEnemyHealthData;
	}

	private void HideUI()
	{
		Animator.SetTrigger("Hide");
	}

	private void ShowUI()
	{
		Animator.SetTrigger("Show");
	}
}
