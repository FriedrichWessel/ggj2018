using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class WalkTowardsGoalAbility : MonoBehaviour
{
	public float BaseSpeed;
	
	private Vector3 _targetPosition;
	private NavMeshAgent _agent;
	private float _activeSpeed;
	private NewWalkTargetSignal _walkTargetSignal;

	// Use this for initialization
	[Inject]
	public void Init (NewWalkTargetSignal walkTargetSignal)
	{
		_agent = gameObject.GetComponent<NavMeshAgent>();
		SetSpeed(BaseSpeed);
		_walkTargetSignal = walkTargetSignal;
		_walkTargetSignal += SetTarget;
	}

	private void OnDestroy()
	{
		_walkTargetSignal -= SetTarget;
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
