using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollAbility : Ability {
	private Rigidbody[] _rigidBodys;
	public Animator Animator; 

	// Use this for initialization
	void Start ()
	{
		_rigidBodys = gameObject.GetComponentsInChildren<Rigidbody>();
		DeactivateRagdoll();
	}

	private void DeactivateRagdoll()
	{
		foreach (var rigidBody in _rigidBodys)
		{
			rigidBody.isKinematic = true;
		}
	}

	void OnDestroy()
	{
		StopAllCoroutines();
	}

	public override void Activate()
	{
		base.Activate();
		foreach (var rigidBody in _rigidBodys)
		{
			rigidBody.isKinematic = false; 
		}
		Animator.enabled = false;
		StartCoroutine(WaitForDisable());
	}

	private IEnumerator WaitForDisable()
	{
		yield return new WaitForSeconds(3);
		DeactivateRagdoll();
		
	}
}
