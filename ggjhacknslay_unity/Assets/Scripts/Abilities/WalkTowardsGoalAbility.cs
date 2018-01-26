using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class WalkTowardsGoalAbility : GoalAbility
{
	public float BaseSpeed;
	
	private NavMeshAgent _agent;
	private float _activeSpeed;

	// Use this for initialization
	[Inject]
	public void Init ()
	{
		_agent = gameObject.GetComponent<NavMeshAgent>();
		SetSpeed(BaseSpeed);
	}

	public void SetSpeed(float newSpeed)
	{
		_activeSpeed = newSpeed;
		_agent.speed = _activeSpeed;
	}

	public override void SetTarget(Vector3 target)
	{
		base.SetTarget(target);
		_agent.SetDestination(_targetPosition);
	}

}
