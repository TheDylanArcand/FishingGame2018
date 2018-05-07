using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSortingAlgorithm : MonoBehaviour
{
	private InventoryScript _InventorySize = new InventoryScript();

	public void InitiateSort(InventoryScript ItemHolder)
	{
		Sort(ItemHolder.Items);
	}

	private void Sort(ItemScript[] Items)
	{
		ItemScript[] ChestplateArray = new ItemScript[_InventorySize.Items.Length];
		ItemScript[] GlovesArray = new ItemScript[_InventorySize.Items.Length];
		ItemScript[] HelmArray = new ItemScript[_InventorySize.Items.Length];
		ItemScript[] PantsArray = new ItemScript[_InventorySize.Items.Length];
		ItemScript[] BootsArray = new ItemScript[_InventorySize.Items.Length];
		ItemScript[] WeaponArray = new ItemScript[_InventorySize.Items.Length];
		int ChestplateIndex = 0;
		int GlovesIndex = 0;
		int HelmIndex = 0;
		int PantsIndex = 0;
		int BootsIndex = 0;
		int WeaponIndex = 0;
		int TotalIndex = 0;

		foreach (ItemScript item in Items)
		{
			switch (item.SlotTag)
			{
				case "Chestpiece":
					ChestplateArray[ChestplateIndex] = new ItemScript(item);
					++ChestplateIndex;
					item.CleanItem();
					break;
				case "Gloves":
					GlovesArray[GlovesIndex] = new ItemScript(item);
					++GlovesIndex;
					item.CleanItem();
					break;
				case "Helm":
					HelmArray[HelmIndex] = new ItemScript(item);
					++HelmIndex;
					item.CleanItem();
					break;
				case "Pants":
					PantsArray[PantsIndex] = new ItemScript(item);
					++PantsIndex;
					item.CleanItem();
					break;
				case "Boots":
					BootsArray[BootsIndex] = new ItemScript(item);
					++BootsIndex;
					item.CleanItem();
					break;
				case "Weapon":
					WeaponArray[WeaponIndex] = new ItemScript(item);
					++WeaponIndex;
					item.CleanItem();
					break;
				default:
					break;
			}
		}

		if (ChestplateIndex > 0)
			TotalIndex = AddToOldList(Items, ChestplateArray, TotalIndex, ChestplateIndex);

		if (GlovesIndex > 0)
			TotalIndex = AddToOldList(Items, GlovesArray, TotalIndex, GlovesIndex);

		if (HelmIndex > 0)
			TotalIndex = AddToOldList(Items, HelmArray, TotalIndex, HelmIndex);

		if (PantsIndex > 0)
			TotalIndex = AddToOldList(Items, PantsArray, TotalIndex, PantsIndex);

		if (BootsIndex > 0)
			TotalIndex = AddToOldList(Items, BootsArray, TotalIndex, BootsIndex);

		if (WeaponIndex > 0)
			TotalIndex = AddToOldList(Items, WeaponArray, TotalIndex, WeaponIndex);

	}

	private int AddToOldList(ItemScript[] MainScript, ItemScript[] TempScript, int Index, int ArrayLength)
	{
		for (int i = Index; i < Index + ArrayLength; i++)
		{
			MainScript[i] = new ItemScript(TempScript[i - Index]);
		}

		return Index + ArrayLength;
	}
}
