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
		ItemScript[] ChestplateArray	= new ItemScript[_InventorySize.Items.Length];
		ItemScript[] GlovesArray		= new ItemScript[_InventorySize.Items.Length];
		ItemScript[] HelmArray			= new ItemScript[_InventorySize.Items.Length];
		ItemScript[] PantsArray			= new ItemScript[_InventorySize.Items.Length];
		ItemScript[] BootsArray			= new ItemScript[_InventorySize.Items.Length];
		ItemScript[] WeaponArray		= new ItemScript[_InventorySize.Items.Length];
		int ChestplateIndex = 0;
		int	GlovesIndex		= 0;
		int	HelmIndex		= 0;
		int	PantsIndex		= 0;
		int	BootsIndex		= 0;
		int WeaponIndex		= 0;
		int TotalIndex		= 0;

		foreach (ItemScript item in Items)
		{
			switch (item.SlotTag)
			{
				case "Chestpiece":
					ChestplateArray[ChestplateIndex] = item;
					++ChestplateIndex;
					item.CleanItem();
					break;
				case "Gloves":
					GlovesArray[GlovesIndex] = item;
					++GlovesIndex;
					item.CleanItem();
					break;
				case "Helm":
					HelmArray[HelmIndex] = item;
					++HelmIndex;
					item.CleanItem();
					break;
				case "Pants":
					PantsArray[PantsIndex] = item;
					++PantsIndex;
					item.CleanItem();
					break;
				case "Boots":
					BootsArray[BootsIndex] = item;
					++BootsIndex;
					item.CleanItem();
					break;
				case "Weapon":
					WeaponArray[WeaponIndex] = item;
					++WeaponIndex;
					item.CleanItem();
					break;
				default:
					break;
			}

			if (ChestplateIndex > 0)
				AddToOldList(Items, ChestplateArray, ChestplateIndex, TotalIndex);

			if (GlovesIndex > 0)
				AddToOldList(Items, GlovesArray, GlovesIndex, TotalIndex);

			if (HelmIndex > 0)
				AddToOldList(Items, HelmArray, HelmIndex, TotalIndex);

			if (PantsIndex > 0)
				AddToOldList(Items, PantsArray, PantsIndex, TotalIndex);

			if (BootsIndex > 0)
				AddToOldList(Items, BootsArray, BootsIndex, TotalIndex);

			if (WeaponIndex > 0)
				AddToOldList(Items, WeaponArray, WeaponIndex, TotalIndex);

		}
	}

	private void AddToOldList(ItemScript[] MainScript, ItemScript[] TempScript, int ArrayLengthIndex, int EndingIndex)
	{
		EndingIndex += ArrayLengthIndex;

		for (int i = ArrayLengthIndex; i < EndingIndex; i++)
		{
			MainScript[i] = TempScript[i - ArrayLengthIndex];
		}
	}
}
