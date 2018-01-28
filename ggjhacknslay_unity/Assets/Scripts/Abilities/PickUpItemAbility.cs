using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemAbility : Ability
{

	public Inventory TargetInventory;

	private void OnTriggerEnter(Collider other)
	{
		var item = other.GetComponent<Item>();
		if (item != null && !item.AttachedToBody)
		{
			TargetInventory.AddItem(item);
		}
	}
}
