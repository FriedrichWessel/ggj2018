using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
	public event Action Deactivated = () => { }; 
	public bool ResistsDeath = false;

	public virtual void Activate()
	{
		
	}

	protected void FireDeactivated()
	{
		Deactivated();
	}

	public virtual  void Cancel()
	{
		
	}
}
