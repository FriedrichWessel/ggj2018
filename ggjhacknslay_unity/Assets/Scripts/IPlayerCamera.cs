using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerCamera
{
	Camera MainCamera { get;  }
	bool GetNavMeshPosition(Vector2 mousePosition, out Vector3 worldPosition);
	TargetableAbility CheckForTarget(Vector2 mousePosition);
}
