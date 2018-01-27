using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ActivateAbilityOnKey : Ability {
	private KeyPressedSignal _keyPressedSignal;

	public KeyCode KeyToMatch;
	public Ability[] Abilities; 
	
	[Inject]
	void Init (KeyPressedSignal keyPressedSignal)
	{
		_keyPressedSignal = keyPressedSignal;
		_keyPressedSignal += ActivateAbilies;
	}

	private void ActivateAbilies(KeyCode keyCode)
	{
		if (keyCode != KeyToMatch)
		{
			return;
		}
		foreach (var ability in Abilities)
		{
			ability.Activate();
		}
	}
}
