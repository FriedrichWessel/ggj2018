using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemType SlotType;
	public LayerMask DeactivationLayer; 
	private Rigidbody _rigidBody;
	

	void Start()
	{
		_rigidBody = gameObject.GetComponent<Rigidbody>();
		_rigidBody.isKinematic = true; 
	}

	public void Drop()
	{
		transform.SetParent(null);
		if (_rigidBody != null)
		{
			_rigidBody.isKinematic = false; 
			_rigidBody.AddForce(new Vector3(0,10,0));
		}
	}

	public void Deactivate()
	{
		if (_rigidBody != null)
		{
			_rigidBody.isKinematic = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (DeactivationLayer == (DeactivationLayer | (1 << other.gameObject.layer)))
		{
			Deactivate();
		}
	}
}
