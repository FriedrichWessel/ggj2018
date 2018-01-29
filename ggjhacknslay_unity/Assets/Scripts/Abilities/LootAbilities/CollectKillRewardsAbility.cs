using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKillRewardsAbility : Ability
{

	public Inventory Inventory;

	public void Collect(List<Item> items)
	{
		base.Activate();
		foreach (var item in items)
		{
			item.Deactivate();
			Inventory.AddItem(item);
			
		}
		
	}
}
