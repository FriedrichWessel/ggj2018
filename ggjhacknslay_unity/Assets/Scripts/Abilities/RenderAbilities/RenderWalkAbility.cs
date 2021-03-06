﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RenderWalkAbility : Ability {
	private const string WALK_BOOL = "Walk";

	public WalkTowardsGoalAbility _walkToTargetAbility;
	public AudioSource Sound;
	private  Animator _animator;

	private bool _isWalking; 
	// Use this for initialization
	[Inject]
	void Init ()
	{
		_animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_walkToTargetAbility == null)
		{
			return;
		}
		if (_walkToTargetAbility.IsWalking && !_isWalking)
		{
			_isWalking = true;
			if (Sound != null)
			{
				Sound.Play();
			}
			_animator.SetBool(WALK_BOOL, _isWalking);
		}
		else if(!_walkToTargetAbility.IsWalking && _isWalking)
		{
			_isWalking = false;
			if (Sound != null)
			{
				Sound.Stop();
			}
			_animator.SetBool(WALK_BOOL, _isWalking);
		}
	}
}
