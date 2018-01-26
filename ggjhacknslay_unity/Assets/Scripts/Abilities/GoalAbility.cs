using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAbility : MonoBehaviour {
	
	protected Vector3 _targetPosition;
	
	public virtual void SetTarget(Vector3 target)
	{
		_targetPosition = target;
	} 
}
