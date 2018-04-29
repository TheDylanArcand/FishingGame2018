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

	private void Awake()
	{

		for (int i = 0; i < NumberOfItemSlots; i++)
		{
			if(Items[i] == null)
				Items[i] = ScriptableObject.CreateInstance<ItemScript>();
		}
	}

	public void AddItem(ItemScript itemToAdd)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if(Items[i].SlotTag == "NotActive".ToString())
			{
				ItemScriptDeepCopy(Items[i], itemToAdd);
				Items[i].name = ("Item #" + i).ToString();
                ItemImages[i] = itemToAdd.Sprite;
				ItemTags[i] = ItemTags.ToString();
				return;
            }
        }
    }

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
				ItemTags[i] = "NotActive".ToString();
				ApplyItemChanges();
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
				ItemSlots[i].GetComponent<Button>().interactable = true;
			}
			else
			{
				ItemSlots[i].GetComponent<Image>().sprite = null;
				ItemSlots[i].GetComponent<Button>().interactable = false;
			}
		}
	}

	public void EnlargeItem(GameObject item)
	{
		EnlargedImage.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
		EnlargedText.text = item.name.ToString();
	}

	private void ItemScriptDeepCopy(ItemScript LHS,  ItemScript RHS)
	{
		LHS.Name = RHS.Name;
		LHS.Sprite = RHS.Sprite;
		LHS.SlotTag = RHS.SlotTag;
	}
}
