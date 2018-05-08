using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A modified inventory script that holds the information of item images, tags, and each slot the item is in
/// </summary>

public class InventoryScript : MonoBehaviour
{
    public const int NumberOfItemSlots = 36;

    public Sprite[] ItemImages = new Sprite[NumberOfItemSlots];
	public ItemScript[] Items = new ItemScript[NumberOfItemSlots];

	public string[] ItemTags = new string[NumberOfItemSlots];

	public GameObject[] ItemSlots = new GameObject[NumberOfItemSlots];

	public GameObject EnlargedImage;
	public Text EnlargedText;

	private const string _UnusedSlot = "00";

	//Fills the Items[i] with blank templates if no items exist in that spot
	private void Awake()
	{
		for (int i = 0; i < NumberOfItemSlots; i++)
		{
			if (Items[i] == null)
			{
				Items[i] = ScriptableObject.CreateInstance<ItemScript>();
				Items[i].name = ("Item #" + i).ToString();
			}
		}
		ApplyItemChanges();
	}

	//Adds a created item into the list
	public void AddItem(ItemScript itemToAdd)
    {
        for (int i = 0; i < Items.Length; i++)
        {
			//Determines of the slot is used or not
            if(Items[i].SlotTag == _UnusedSlot)
			{
				Items[i] = new ItemScript(itemToAdd);

				//Displays the item you have recieved
                ItemImages[i] = itemToAdd.Sprite;
				ItemTags[i] = ItemTags.ToString();
				return;
            }
        }
    }

	//Removes the item from the list
    public void RemoveItem(ItemScript itemToRemove)
    {
		itemToRemove.Sprite = EnlargedImage.GetComponent<Image>().sprite;
		itemToRemove.Name = EnlargedText.text.ToString();

        for (int i = 0; i < Items.Length; i++)
        {
			if (Items[i].Name == itemToRemove.Name && Items[i].Sprite == itemToRemove.Sprite)
            {
				Items[i] = ScriptableObject.CreateInstance<ItemScript>();
				ItemImages[i] = null;
				ItemTags[i] = _UnusedSlot;
				ApplyItemChanges();
				return;
            }
        }
    }

	//Sets the item button on the inventory screen either active or inactive depending on if there is an item in
	//	in it or not
	public void ApplyItemChanges()
	{
		for (int i = 0; i < NumberOfItemSlots; i++)
		{
			if (Items[i]!= null && Items[i].SlotTag != _UnusedSlot)
			{
				ItemSlots[i].GetComponent<Image>().sprite = Items[i].Sprite;
				ItemSlots[i].name = Items[i].Name;
				ItemSlots[i].GetComponent<Button>().interactable = true;
			}
			else
			{
				ItemSlots[i].GetComponent<Image>().sprite = null;
				ItemSlots[i].GetComponent<Button>().interactable = false;
			}
		}
	}

	//Brings the item in an enlarged image
	public void EnlargeItem(GameObject item)
	{
		EnlargedImage.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
		EnlargedText.text = item.name.ToString();
	}
}
