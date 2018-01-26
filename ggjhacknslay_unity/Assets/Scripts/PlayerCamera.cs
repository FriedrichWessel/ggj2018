using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCamera : MonoBehaviour, IPlayerCamera {

	public Camera MainCamera { get; private set; }
	public LayerMask NavMeshLayer; 
	
	[Inject]
	void Init()
	{
		MainCamera = gameObject.GetComponent<Camera>();
	}

	public bool GetNavMeshPosition(Vector2 mousePosition, out Vector3 position)
	{
		position = Vector3.zero;
		RaycastHit hit; 
		var ray = MainCamera.ScreenPointToRay(mousePosition);
		Debug.DrawRay(ray.origin, ray.direction*100, Color.cyan, 10);
		if (Physics.Raycast(ray, out hit, float.PositiveInfinity,  NavMeshLayer))
		{
			position = hit.point;
			return true;
		}
		return false;
	}
}
