﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	public string Name;
	public Sprite Icon;
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
		this.transform.position = new Vector3(pos.x, 0.5f, pos.z);
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
