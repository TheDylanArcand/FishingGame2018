using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSortingAlgorithm : MonoBehaviour
{
	private InventoryScript _InventorySize = new InventoryScript();

	public void InitiateSort()
	{
		Sort(ref InventoryScript.InventoryInstance.Inventory);
	}
	
	private void Sort(ref InventoryScript.ItemStruct[] Items)
	{
		InventoryScript.ItemStruct[] ChestplateArray =	new InventoryScript.ItemStruct[_InventorySize.Inventory.Length];
		InventoryScript.ItemStruct[] GlovesArray =		new InventoryScript.ItemStruct[_InventorySize.Inventory.Length];
		InventoryScript.ItemStruct[] HelmArray =		new InventoryScript.ItemStruct[_InventorySize.Inventory.Length];
		InventoryScript.ItemStruct[] PantsArray =		new InventoryScript.ItemStruct[_InventorySize.Inventory.Length];
		InventoryScript.ItemStruct[] BootsArray =		new InventoryScript.ItemStruct[_InventorySize.Inventory.Length];
		InventoryScript.ItemStruct[] WeaponArray =		new InventoryScript.ItemStruct[_InventorySize.Inventory.Length];
		int ChestplateIndex = 0;
		int GlovesIndex = 0;
		int HelmIndex = 0;
		int PantsIndex = 0;
		int BootsIndex = 0;
		int WeaponIndex = 0;
		int TotalIndex = 0;
	
		foreach (InventoryScript.ItemStruct item in Items)
		{
			switch (item.ItemTag)
			{
				case "Chestpiece":
					TempArrayFiller(ref ChestplateIndex	, ChestplateArray	, item);
					break;
				case "Gloves":
					TempArrayFiller(ref GlovesIndex		, GlovesArray		, item);
					break;
				case "Helm":
					TempArrayFiller(ref HelmIndex		, HelmArray			, item);
					break;
				case "Pants":
					TempArrayFiller(ref PantsIndex		, PantsArray		, item);
					break;
				case "Boots":
					TempArrayFiller(ref BootsIndex		, BootsArray		, item);
					break;
				case "Weapon":
					TempArrayFiller(ref WeaponIndex		, WeaponArray		, item);
					break;
				default:
					break;
			}
			item.CleanItem();
		}
	
		if (ChestplateIndex > 0)
			TotalIndex = AddToOldList(Items, ChestplateArray, TotalIndex, ChestplateIndex);
	
		if (GlovesIndex		> 0)
			TotalIndex = AddToOldList(Items, GlovesArray	, TotalIndex, GlovesIndex);
	
		if (HelmIndex		> 0)
			TotalIndex = AddToOldList(Items, HelmArray		, TotalIndex, HelmIndex);
	
		if (PantsIndex		> 0)
			TotalIndex = AddToOldList(Items, PantsArray		, TotalIndex, PantsIndex);
	
		if (BootsIndex		> 0)
			TotalIndex = AddToOldList(Items, BootsArray		, TotalIndex, BootsIndex);
	
		if (WeaponIndex		> 0)
			TotalIndex = AddToOldList(Items, WeaponArray	, TotalIndex, WeaponIndex);
	
	}

	private void TempArrayFiller(ref int index, InventoryScript.ItemStruct[] array, InventoryScript.ItemStruct item)
	{
		array[index] = new InventoryScript.ItemStruct(item);
		++index;
	}
	
	private int AddToOldList(InventoryScript.ItemStruct[] MainScript, InventoryScript.ItemStruct[] TempScript, int Index, int ArrayLength)
	{
		for (int i = Index; i < Index + ArrayLength; i++)
		{
			MainScript[i] = new InventoryScript.ItemStruct(TempScript[i - Index]);
		}
	
		return Index + ArrayLength;
	}
}
