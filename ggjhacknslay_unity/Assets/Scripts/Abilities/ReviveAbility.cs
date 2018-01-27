using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Object = UnityEngine.Object;

public class ReviveAbility : Ability
{
	public Transform ReviveSpot;
	public NavMeshAgent AgentToPlace;
	public float ReviveWaitTime;
	public Animator ReviveAnimator;
	public HealthData Data;
	private GameStartSignal _gameStartSignal;

	[Inject]
	private void Init(GameStartSignal startSignal)
	{
		_gameStartSignal = startSignal;
	}

	public override void Activate()
	{
		base.Activate();
		var deadData = gameObject.GetComponent<DeadData>();
		if (deadData != null)
		{
			StartCoroutine(WaitForeRevive(deadData)); 
		}
	}

	private IEnumerator WaitForeRevive(DeadData deadData)
	{
		yield return new WaitForSeconds(ReviveWaitTime);
		 
		ReviveAnimator.SetTrigger("Revive");
		Object.Destroy(deadData);
		var abilities = gameObject.GetComponents<Ability>();
		var childAbilities = gameObject.GetComponentsInChildren<Ability>();
		var behaviours = gameObject.GetComponentsInParent<Behaviour>();
		Data.CurrentHealth = Data.BaseHealth;
		foreach (var ability in abilities)
		{
			ability.enabled = true; 
		}
		foreach (var ability in childAbilities)
		{
			ability.enabled = true; 
		}
		foreach (var behaviour in behaviours)
		{
			throw new NotImplementedException("Behaciour revive is not done yet");
			
		}
		AgentToPlace.isStopped = true; 
		AgentToPlace.transform.position = ReviveSpot.position;
		AgentToPlace.nextPosition = ReviveSpot.position;
		AgentToPlace.SetDestination(ReviveSpot.position);
		_gameStartSignal.Fire();
	}
}
