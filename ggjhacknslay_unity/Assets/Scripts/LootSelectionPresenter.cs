using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LootSelectionPresenter : MonoBehaviour
{

	public ItemPresenter Presenter1;
	public ItemPresenter Presenter2;
	private Item _item1;
	private Item _item2;
	private ItemSelectedSignal _itemSelectedSignal;

	[Inject]
	private void Init(ItemSelectedSignal signal)
	{
		_itemSelectedSignal = signal;
	}

	public void ShowPicker(Item item1, Item item2)
	{
		_item1 = item1; 
		_item2 = item2; 
		Presenter1.ShowItem(item1);
		Presenter2.ShowItem(item2);
		this.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void SelectItem1()
	{
		Time.timeScale = 1;
		_itemSelectedSignal.Fire(_item1);
		this.gameObject.SetActive(false);
	}
	public void SelectItem2()
	{
		Time.timeScale =1; 
		_itemSelectedSignal.Fire(_item2);
		this.gameObject.SetActive(false);
	}
	



}
