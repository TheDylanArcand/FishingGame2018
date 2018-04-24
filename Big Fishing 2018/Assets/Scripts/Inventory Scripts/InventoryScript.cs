using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public const int NumberOfItemSlots = 36;

    public Sprite[] ItemImages = new Sprite[NumberOfItemSlots];
    public ItemScript[] Items = new ItemScript[NumberOfItemSlots];
	public string[] ItemTags = new string[NumberOfItemSlots];

	public GameObject[] ItemSlots = new GameObject[NumberOfItemSlots];

	public GameObject EnlargedImage;
	public Text EnlargedText;
	private string EnlargedSlot;

	public void AddItem(ItemScript itemToAdd)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if(Items[i] == null)
            {
                Items[i] = itemToAdd;
                ItemImages[i] = itemToAdd.Sprite;
				ItemTags[i] = ItemTags.ToString();
				return;
            }
        }
    }

    public void RemoveItem(ItemScript itemToRemove)
    {
		itemToRemove.Sprite = EnlargedImage.GetComponent<Sprite>();
		itemToRemove.Name = EnlargedText.text.ToString();

        for (int i = 0; i < Items.Length; i++)
        {
			if (Items[i] == itemToRemove)
            {
                Items[i] = null;
                ItemImages[i] = null;
				ItemTags[i] = "NotActive".ToString();
                return;
            }
        }
    }

	public void ApplyItemChanges()
	{
		for (int i = 0; i < NumberOfItemSlots; i++)
		{
			if (Items[i]!= null && Items[i].SlotTag != "NotActive".ToString())
			{
				ItemSlots[i].GetComponent<Image>().sprite = Items[i].Sprite;
				ItemSlots[i].name = Items[i].Name;
			}
			else
			{
				ItemSlots[i].GetComponent<Button>().interactable = false;
			}
		}
	}

	public void EnlargeItem(GameObject item)
	{
		EnlargedImage.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
		EnlargedText.text = item.name.ToString();
	}
}
