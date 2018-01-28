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
		foreach (var rigidBody in _rigidBodys)
		{
			rigidBody.isKinematic = true; 
		}
	}

	public override void Activate()
	{
		base.Activate();
		foreach (var rigidBody in _rigidBodys)
		{
			rigidBody.isKinematic = false; 
		}
		Animator.enabled = false;
	}
}
