using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLootFromInventoryAbility : DropLootAbility
{

	public float WaitTime; 
	public Inventory InventoryToLoot;

	public override void Activate()
	{
		base.Activate();
		var items = InventoryToLoot.DropInventory();
		StartCoroutine(WaitForLootDrop(items));
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	private IEnumerator WaitForLootDrop(List<Item> items)
	{
		yield return new WaitForSeconds(WaitTime);
		var healthData = gameObject.GetComponent<HealthData>();
		if (healthData.LastDamageDealer != null)
		{
			var receiver = healthData.LastDamageDealer.GetComponent<CollectKillRewardsAbility>();
			if (receiver != null && receiver.enabled)
			{
				receiver.Collect(items);
			}
		}

	}

}
