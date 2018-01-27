using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class RenderDeadAbility : Ability {
	private const string DEAD_ANIM = "Die";
	
	private DeadData _deadData;

	public Animator AnimationControl; 
	
	void Update()
	{
		if (_deadData == null)
		{
			_deadData = gameObject.GetComponent<DeadData>();
		}
		if (_deadData != null && !_deadData.Dying)
		{
			_deadData.Dying = true; 
			AnimationControl.SetTrigger("Die");
		}

	}

}
