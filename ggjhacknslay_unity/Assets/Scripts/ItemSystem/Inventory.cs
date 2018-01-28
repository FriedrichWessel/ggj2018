﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public ItemSlot[] ItemAttachmentPoints; 
	
	private Dictionary<ItemType,Item> Items = new Dictionary<ItemType, Item>();
	public Item[] StartItems;

	void Start()
	{
		foreach (var item in StartItems)
		{
			AddItem(item);
		}
	}

	public void AddItem(Item item)
	{
		if (!Items.ContainsKey(item.SlotType))
		{
			Items.Add(item.SlotType, item);
		}
		var healtData = this.gameObject.GetComponentInChildren<HealthData>();
		if (healtData != null)
		{
			if (item.ArmorValue > 0)
			{
				healtData.ArmorItems.Push(item);
			}
		}
		item.SetParentInventory(this);
		item.AttachedToBody = true;
		Items[item.SlotType] = item;
		UpdateItemView();
	}

	private void UpdateItemView()
	{
		foreach (var itemSlot in ItemAttachmentPoints)
		{
			if (Items.ContainsKey(itemSlot.ItemType))
			{
				var item = Items[itemSlot.ItemType].transform; 
				item.SetParent(itemSlot.AttachmentPoint);
				item.localPosition = Vector3.zero; 
				item.localRotation = Quaternion.identity;
				item.localScale = Vector3.one;
			}
		}
	}

	public List<Item> DropInventory()
	{
		var result = new List<Item>();
		foreach (var item in Items)
		{
			result.Add(item.Value);
			item.Value.Drop();
		}
		
		Items.Clear();
		
		return result;
	}

	[Serializable]
	public class ItemSlot
	{
		public Transform AttachmentPoint;
		public ItemType ItemType;

	}

	public void DestroyItem(Item item)
	{
		 if (Items.ContainsKey(item.SlotType) && Items[item.SlotType] == item)
		 {
			 Items.Remove(item.SlotType);
		 }
	}
}
