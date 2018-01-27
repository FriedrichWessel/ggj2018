using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
	public event Action Finished = () => { };

	protected void FireFinished()
	{
		Finished();
	}

	public virtual  void Tick()
	{
	}

	public virtual void Cancel()
	{
		
	}
}
