using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPresenter : MonoBehaviour
{
	public Text ArmorLabel;
	public Text AttackLabel;
	public Text NameLabel;
	public Image Icon;

	public Sprite DefaultArmor; 
	public Sprite DefaultHelm;
	
	
	public void ShowItem(Item item)
	{
		NameLabel.text = item.Name;
		ArmorLabel.text = ArmorLabel.text.Replace("{VAL}", item.ArmorValue.ToString());
		AttackLabel.text = AttackLabel.text.Replace("{VAL}", item.AttackValue.ToString());
		if (item.Icon != null)
		{
			Icon.sprite = item.Icon;
		}
		else
		{
			if (item.SlotType == ItemType.Body)
			{
				Icon.sprite = DefaultArmor;
			}
			if (item.SlotType == ItemType.Head)
			{
				Icon.sprite = DefaultHelm;
			}
		}
	}

}
