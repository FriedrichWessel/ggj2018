using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputSystem  : ITickable{
	private IPlayerCamera _playerCamera;
	private NewWalkTargetSignal _walkTargetSignal;
	private KeyPressedSignal _keyPressedSignal;

	public InputSystem(IPlayerCamera camera,
		NewWalkTargetSignal walkTargetSignal,
		KeyPressedSignal keyPressedSignal
		)
	{
		_playerCamera = camera;
		_walkTargetSignal = walkTargetSignal;
		_keyPressedSignal = keyPressedSignal;
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
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_keyPressedSignal.Fire(KeyCode.Space);
		}
	}
}
