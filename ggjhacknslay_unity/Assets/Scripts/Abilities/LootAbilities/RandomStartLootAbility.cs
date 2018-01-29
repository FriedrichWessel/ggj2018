using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RandomStartLootAbility : Ability
{

	public Inventory InventoryToFill;
	public ItemConfiguration ItemConfig; 
	
	private IRandomGenerator _rnd;
	private IObjectInstantiator _instantiator;

	[Inject]
	private void Init(IRandomGenerator rnd, IObjectInstantiator instantiator)
	{
		_rnd = rnd;
		_instantiator = instantiator;
		LoadLoot(); 
	}

	private void LoadLoot()
	{
		foreach (var point in InventoryToFill.ItemAttachmentPoints)
		{
			var rndNumber = _rnd.Range(0, 100);
			if (rndNumber > 75)
			{
				var itemPrefab = PickItemForSlow(point.ItemType);
				var item = _instantiator.Instantiate<Item>(itemPrefab);
				InventoryToFill.AddItem(item);

			}
		}
		
	}

	private Item PickItemForSlow(ItemType pointItemType)
	{
		int itemIndex = 0;
		switch (pointItemType)
		{
			case ItemType.Body:
				itemIndex = Mathf.FloorToInt(_rnd.Range(0, ItemConfig.AvailableBodyItems.Length - 1));
				return ItemConfig.AvailableBodyItems[itemIndex];
			case ItemType.Head:
				itemIndex = Mathf.FloorToInt(_rnd.Range(0, ItemConfig.AvailableHeadItems.Length - 1));
				return ItemConfig.AvailableBodyItems[itemIndex];
		}
		throw new NotImplementedException(string.Format("ItemType {0} is not confidured in ItemConfig", pointItemType));
	}
}
