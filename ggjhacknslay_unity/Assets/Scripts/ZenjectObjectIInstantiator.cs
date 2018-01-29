using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenjectObjectIInstantiator : IObjectInstantiator {
	private DiContainer _container;

	public ZenjectObjectIInstantiator(DiContainer container)
	{
		_container = container;
	}

	public T Instantiate<T>(Object prefab)
	{
		return Instantiate<T>(prefab, Vector3.zero);
	}

	public T Instantiate<T>(Object prefab, Vector3 position)
	{
		return Instantiate<T>(prefab, position, Quaternion.identity);
	}

	public T Instantiate<T>(Object prefab, Vector3 position, Quaternion rotation)
	{
		return Instantiate<T>(prefab, position, rotation, null);
	}

	public T Instantiate<T>(Object prefab, Vector3 position, Quaternion rotation, Transform parent)
	{
		var loadedObject = _container.InstantiatePrefab(prefab, position, rotation, parent);
		T result = loadedObject.GetComponent<T>();
		return result;
	}
}
