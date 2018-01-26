using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class WalkTowardsGoalAbility : MonoBehaviour
{
	public float BaseSpeed;
	
	private Vector3 _targetPosition;
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

	public void SetTarget(Vector3 target)
	{
		_targetPosition = target;
		_agent.SetDestination(_targetPosition);
	}

}
