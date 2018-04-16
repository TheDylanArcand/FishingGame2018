using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public const int NumberOfItemSlots = 4;

    public RawImage[] ItemImages = new RawImage[NumberOfItemSlots];
    public ItemScript[] Items = new ItemScript[NumberOfItemSlots];

    public void AddItem(ItemScript itemToAdd)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if(Items[i] == null)
            {
                Items[i] = itemToAdd;
                ItemImages[i] = itemToAdd.RawImage;
                return;
            }
        }
    }

    public void RemoveItem(ItemScript itemToRemove)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == itemToRemove)
            {
                Items[i] = null;
                ItemImages[i] = null;
                return;
            }
        }
    }
}
