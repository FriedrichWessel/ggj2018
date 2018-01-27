using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DamageAbility : Ability {

	protected DamageData Data;

	[Inject]
	private void Init()
	{
		Data = gameObject.GetComponent<DamageData>();
	}
}
