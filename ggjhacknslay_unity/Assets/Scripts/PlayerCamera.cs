using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCamera : MonoBehaviour, IPlayerCamera {

	public Camera MainCamera { get; private set; }
	public LayerMask NavMeshLayer;
	public LayerMask TargetLayer;
	public float ScreenNoiseTime;
	public GameObject ScreenNoiseObject;
	private GameOverSignal _gameOverSignal;

	[Inject]
	void Init(GameOverSignal gameOverSignal)
	{
		MainCamera = gameObject.GetComponent<Camera>();
		_gameOverSignal = gameOverSignal;
		_gameOverSignal += StartScreenNoise; 
	}

	void OnDestroy()
	{
		_gameOverSignal -= StartScreenNoise;
		StopAllCoroutines();
	}

	private void StartScreenNoise()
	{
		
		StartCoroutine(ScreenNoise());
	}

	private IEnumerator ScreenNoise()
	{
		ScreenNoiseObject.SetActive(true);
		yield return new WaitForSeconds(ScreenNoiseTime);
		ScreenNoiseObject.SetActive(false);
		
	}

	public bool GetNavMeshPosition(Vector2 mousePosition, out Vector3 position)
	{
		position = Vector3.zero;
		RaycastHit hit; 
		var ray = MainCamera.ScreenPointToRay(mousePosition);
		if (Physics.Raycast(ray, out hit, float.PositiveInfinity,  NavMeshLayer))
		{
			position = hit.point;
			return true;
		}
		return false;
	}

	public TargetableAbility CheckForTarget(Vector2 mousePosition)
	{
		TargetableAbility target = null;
		RaycastHit hit; 
		var ray = MainCamera.ScreenPointToRay(mousePosition);
		if (Physics.Raycast(ray, out hit, float.PositiveInfinity, TargetLayer))
		{
			target = hit.collider.GetComponent<TargetableAbility>();
		}
		return target;
	}
}
