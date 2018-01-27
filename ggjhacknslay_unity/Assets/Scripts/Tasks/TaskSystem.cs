using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class TaskSystem : ITickable {
	
	private Dictionary<int, Queue<Task>> ActiveTaskQueue = new Dictionary<int, Queue<Task>>();
	private List<ActiveTask> _activeTask = new List<ActiveTask>(); 
	
	public void EnqueueTask(Task task)
	{
		var hash = task.OwnerHash ;
		if (!ActiveTaskQueue.ContainsKey(hash))
		{
			ActiveTaskQueue.Add(hash, new Queue<Task>());
			_activeTask.Add(new ActiveTask(hash));
		}
		ActiveTaskQueue[hash].Enqueue(task);
		
	}

	public void Tick()
	{
		
		for(int i= 0; i < _activeTask.Count; i++)
		{
			var task = _activeTask[i];
			if (task.TaskToActivate== null && ActiveTaskQueue[task.OwnerHash].Count > 0 )
			{
				task.TaskToActivate = ActiveTaskQueue[task.OwnerHash].Dequeue();
				task.TaskToActivate.Finished += DeactivateTask;  
			} 
			if(task.TaskToActivate != null )
			{
				task.TaskToActivate.Tick();
			}
			_activeTask[i] = task;
		}
	
	}

	private void DeactivateTask(Task t)
	{
		for (int i = 0; i < _activeTask.Count; i++)
		{
			var task = _activeTask[i];
			if (task.TaskToActivate != t)
			{
				continue;
			}
			task.TaskToActivate.Finished -= DeactivateTask;
			_activeTask[i].TaskToActivate = null;
		}
		
	}

	public void StopAll(object owner)
	{
		var hash = RuntimeHelpers.GetHashCode(owner);
		for (int i = 0; i < _activeTask.Count; i++)
		{
			var task = _activeTask[i];
			if (task.OwnerHash != RuntimeHelpers.GetHashCode(owner))
			{
				continue;
			}
			if (task.TaskToActivate != null)
			{
				task.TaskToActivate.Cancel();
				task.TaskToActivate = null; 
			}
			ActiveTaskQueue[hash].Clear();
		}
		
	}

	private class ActiveTask
	{
		public Task TaskToActivate;
		public int OwnerHash; 
		public ActiveTask(int hash)
		{
			OwnerHash = hash;
		}

	}
}
