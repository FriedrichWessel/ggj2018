using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputSystem  : ITickable{
	private IPlayerCamera _playerCamera;
	private NewWalkTargetSignal _walkTargetSignal;
	private KeyPressedSignal _keyPressedSignal;
	private TargetAquiredSignal _targetAquiredSignal;

	public InputSystem(IPlayerCamera camera,
		NewWalkTargetSignal walkTargetSignal,
		KeyPressedSignal keyPressedSignal, 
		TargetAquiredSignal targetAquiredSignal
		)
	{
		_playerCamera = camera;
		_walkTargetSignal = walkTargetSignal;
		_keyPressedSignal = keyPressedSignal;
		_targetAquiredSignal = targetAquiredSignal;
	}

	public void Tick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 targetPos;
			var newTarget = _playerCamera.CheckForTarget(Input.mousePosition);
			if (newTarget != null)
			{
				_targetAquiredSignal.Fire(newTarget);	
			} 
			else if (_playerCamera.GetNavMeshPosition(Input.mousePosition, out targetPos))
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
