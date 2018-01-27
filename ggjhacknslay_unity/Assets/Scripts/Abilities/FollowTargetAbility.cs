using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetAbility : Ability
{

	public Transform Target;
	private Vector3 _startOffset; 
	void Start()
	{
		_startOffset = transform.position - Target.position;
	}

	void Update()
	{
		var pos = transform.position;
		var targetHelper = pos - _startOffset;
		var moveDist = ( targetHelper - Target.position);
		transform.position = pos - moveDist;
	}
}
