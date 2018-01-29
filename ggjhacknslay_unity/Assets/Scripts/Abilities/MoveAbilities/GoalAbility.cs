using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAbility : Ability {
	
	protected Vector3 _targetPosition;
	public Vector3 ActiveTargetPosition {
		get { return _targetPosition;  }
	}

	public virtual void SetTarget(Vector3 target)
	{
		_targetPosition = target;
	} 
}
