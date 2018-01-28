using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using Zenject;

public class AttackAbility : Ability
{
	public DamageAbility[] DamageAbilities;
	public Collider CollsionArea;
	public CooldownData Data;

	public float WarmUpTime;
	public float ActiveTime;
	private GameModel _model;

	public bool IsActive { get; private set;  }

	[Inject]
	void Init(GameModel model)
	{
		CollsionArea.enabled = false;
		_model = model;
	}

	public override void Activate()
	{
		if (IsActive) return;
		base.Activate();
		Attack();
	}

	public override void Cancel()
	{
		base.Cancel();
		StopAllCoroutines();
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
		FireDeactivated();
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	private IEnumerator RunAttack()
	{
		if (_model.CurrentTarget != null)
		{
			this.transform.root.LookAt(_model.CurrentTarget.transform);
		}
		yield return new WaitForSeconds(WarmUpTime);
		CollsionArea.enabled = true; 
		foreach (var ability in DamageAbilities)
		{
			ability.enabled = true;
		}
		yield return new WaitForSeconds(ActiveTime);
		foreach (var ability in DamageAbilities)
		{
			ability.enabled = false;
		}
		CollsionArea.enabled = false; 

	}
}
