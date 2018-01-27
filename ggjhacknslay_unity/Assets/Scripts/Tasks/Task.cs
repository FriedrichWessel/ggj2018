using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Task
{
	private object _owner;
	public event Action<Task> Finished = (t) => { };

	public Task(object owner)
	{
		_owner = owner;
	}

	public int OwnerHash {
		get { return RuntimeHelpers.GetHashCode(_owner); }
	}

	protected void FireFinished()
	{
		Finished(this);
	}

	public virtual  void Tick()
	{
	}

	public virtual void Cancel()
	{
		
	}
}
