using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour
{
	public float CurrentHealth { get; set; }
	public float ArmorValue {
		get
		{
			float result = 0;
			foreach (var armorItem in ArmorItems)
			{
				result += armorItem.ArmorValue;
			}
			return result;
		}
	}

	public float BaseHealth;
	public DamageAbility LastDamageDealer;
	public string Name;
	public Stack<Item> ArmorItems = new Stack<Item>();

	void Start()
	{
		CurrentHealth = BaseHealth; 
	}

	public void RemoveArmorItem(Item newItem)
	{
		var stack = new Stack<Item>();
		while (ArmorItems.Count > 0)
		{
			var item = ArmorItems.Pop();
			if (item != newItem)
			{
				stack.Push(newItem);
			}
		}
		ArmorItems = stack;
	}
}
