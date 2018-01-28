using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RenderDamageAbility : Ability
{
	public HealthData Data;
	public Animator Animator;  

	private float _lastSeenData;
	private bool _firstUpdate = true; 
	
	[Inject]
	void Init()
	{
		_lastSeenData = Data.CurrentHealth;
	}

	// Update is called once per frame
	void Update () {
		if (_firstUpdate)
		{
			_lastSeenData = Data.CurrentHealth;
			_firstUpdate = false;
		}
		if (_lastSeenData != Data.CurrentHealth)
		{
			_lastSeenData = Data.CurrentHealth;
			Animator.SetTrigger("Hit");
		}
	}
}
