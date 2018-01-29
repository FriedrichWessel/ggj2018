using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetAbility : Ability
{

	public Transform Target;

	public void Update()
	{
		transform.LookAt(Target, Vector3.up);
	}
}
