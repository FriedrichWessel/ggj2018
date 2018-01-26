using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputSystem  : ITickable{
	private IPlayerCamera _playerCamera;
	private NewWalkTargetSignal _walkTargetSignal;

	public InputSystem(IPlayerCamera camera, NewWalkTargetSignal walkTargetSignal)
	{
		_playerCamera = camera;
		_walkTargetSignal = walkTargetSignal;
	}

	public void Tick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 targetPos;
			if (_playerCamera.GetNavMeshPosition(Input.mousePosition, out targetPos))
			{
				_walkTargetSignal.Fire(targetPos);
			}
		}
	}
}
