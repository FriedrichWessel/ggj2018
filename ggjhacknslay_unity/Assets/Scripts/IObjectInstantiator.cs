using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectInstantiator
{
	T Instantiate<T>(Object prefab); 
	T Instantiate<T>(Object prefab, Vector3 position);
	T Instantiate<T>(Object prefab, Vector3 position, Quaternion rotation);
	T Instantiate<T>(Object prefab, Vector3 position, Quaternion rotation, Transform parent);
}
