using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : Ability
{
	public DamageAbility[] DamageAbilities;
	public CooldownData Data;

	public float WarmUpTime;
	public float ActiveTime;

	public bool IsActive { get; private set;  }

	public override void Activate()
	{
		if (IsActive) return;
		base.Activate();
		Attack();
	}

	public void Attack()
	{
		if (IsActive)
			return;
		IsActive = true;
		StartCoroutine(WaitForCoolDown());
		StartCoroutine(RunAttack());
	}

	private IEnumerator WaitForCoolDown()
	{
		yield return new WaitForSeconds(Data.Cooldown);
		IsActive = false;
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	private IEnumerator RunAttack()
	{
		yield return new WaitForSeconds(WarmUpTime);
		foreach (var ability in DamageAbilities)
		{
			ability.enabled = true;
		}
		yield return new WaitForSeconds(ActiveTime);
		foreach (var ability in DamageAbilities)
		{
			ability.enabled = false;
		}
		
	}
}
