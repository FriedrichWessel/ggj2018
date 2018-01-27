using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class WalkTowardsGoalAbility : GoalAbility
{
	private SpeedData Speed; 
	private NavMeshAgent _agent;
	private float _activeSpeed;
	public bool IsWalking {
		get { return _agent.velocity.magnitude > 0.5f;  }
	}

	public float DistanceToTarget
	{
		get { return (this.transform.position - _targetPosition).magnitude; }
	}

	// Use this for initialization
	[Inject]
	public void Init ()
	{
		_agent = gameObject.GetComponent<NavMeshAgent>();
		Speed = gameObject.GetComponent<SpeedData>();
		SetSpeed(Speed.Speed);
	}

	public void SetSpeed(float newSpeed)
	{
		if (!this.enabled) return;
		
		_activeSpeed = newSpeed;
		_agent.speed = _activeSpeed;
	}

	public override void SetTarget(Vector3 target)
	{
		if(!this.enabled) return;
		
		_agent.isStopped = false;
		base.SetTarget(target);
		_agent.SetDestination(_targetPosition);
	}

	public override void Cancel()
	{
		CancelWalk();
	}

	public void CancelWalk()
	{
		_agent.isStopped = true;
		
	}
}
