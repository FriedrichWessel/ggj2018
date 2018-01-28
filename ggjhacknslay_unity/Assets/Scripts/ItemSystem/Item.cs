using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemType SlotType;
	public LayerMask DeactivationLayer; 
	private Rigidbody _rigidBody;
	public bool AttachedToBody = false;
	public float ArmorValue { get; set; }
	public float AttackValue { get; set; }
	private Inventory _inventory;
	public float BaseArmor;
	public float BaseAttack; 

	void Start()
	{
		_rigidBody = gameObject.GetComponent<Rigidbody>();
		_rigidBody.isKinematic = true;
		ArmorValue = BaseArmor;
		AttackValue = BaseAttack;
	}

	private void OnDestroy()
	{
		if (_inventory != null)
		{
			_inventory.DestroyItem(this);
		}
	}

	public void SetParentInventory(Inventory inv)
	{
		_inventory = inv; 
	}

	public void Drop()
	{
		ArmorValue = BaseArmor;
		AttackValue = BaseAttack;
		ThrowAway();
	}

	public void ThrowAway()
	{
		gameObject.SetActive(true);
		transform.SetParent(null);
		var pos = this.transform.position; 
		this.transform.position = new Vector3(pos.x, 0, pos.z);
		/*if (_rigidBody != null)
		{
			_rigidBody.isKinematic = false;
			_rigidBody.AddForce(new Vector3(0, 10, 0));
		}*/
		AttachedToBody = false;
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
