using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TaskSystem : ITickable {
	
	private  Queue<Task> ActiveTaskQueue = new Queue<Task>();
	private Task _activeTask; 
	
	public void EnqueueTask(Task task)
	{
		ActiveTaskQueue.Enqueue(task);
	}

	public void Tick()
	{
		if (_activeTask == null && ActiveTaskQueue.Count > 0 )
		{
			_activeTask = ActiveTaskQueue.Dequeue();
			_activeTask.Finished += DeactivateTask;  
		}
		if(_activeTask != null )
		{
			_activeTask.Tick();
		}
	}

	private void DeactivateTask()
	{
		_activeTask.Finished -= DeactivateTask;
		_activeTask = null;
	}

	public void StopAll()
	{
		if (_activeTask != null)
		{
			_activeTask.Cancel();
			_activeTask = null; 
		}
		ActiveTaskQueue.Clear();
	}
}
