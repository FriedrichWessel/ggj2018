using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RenderAttackAbility : MonoBehaviour
{
	private const string ATTACK_TRIGGER = "Attack";
	
	public Animator AnimationControl;
	public AttackAbility Ability; 
	
	private bool _triggered = false; 
	// Update is called once per frame
	void Update () {
		if (Ability.IsActive && !_triggered)
		{
			AnimationControl.SetTrigger(ATTACK_TRIGGER);
			_triggered = true; 
		} else if (!Ability.IsActive && _triggered)
		{
			_triggered = false; 
		}
	}
}
