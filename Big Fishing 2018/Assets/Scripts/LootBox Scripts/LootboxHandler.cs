using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootboxHandler : MonoBehaviour
{
    public GameObject LootBox;
    public List<Sprite> LootItem;
    public Text ItemText;
	public Image ItemImage;
	public ItemScript CreatedLoot;
	public InventoryScript ItemTransferer;
	public Text LootboxText;
    
    private int _LootIndex;
    private Dictionary<int, Sprite> _LootItemDictionary = new Dictionary<int, Sprite>();

	void Awake ()
    {
        Random.InitState((int)System.DateTime.Now.Millisecond + System.DateTime.Now.Minute);

        if (LootItem != null)
        {
            for (int i = 0; i < LootItem.Count; i++)
            {
                _LootItemDictionary.Add(i, LootItem[i]);
            }
        }

		LootboxText.text = "Lootboxes: " + UserStatsScript.Instance.LootBoxCount;
	}
	
    public void OpenLootBox()
    {
        LootBox.SetActive(false);

        _LootIndex = RandomIndex(_LootItemDictionary);

        ItemImage.sprite = _LootItemDictionary[_LootIndex];

		ItemImage.gameObject.SetActive(true);
        ItemText.gameObject.SetActive(true);

		CreatedLoot.Sprite = _LootItemDictionary[_LootIndex];
		ItemText.text = CreatedLoot.Name = GenerateName(_LootIndex).ToString();
		ItemTransferer.AddItem(CreatedLoot);

		UserStatsScript.Instance.LootBoxCount--;
		LootboxText.text = "Lootboxes: " + UserStatsScript.Instance.LootBoxCount;

	}

    public void CloseLootBox()
    {
        LootBox.SetActive(true);

		ItemImage.gameObject.SetActive(false);

        ItemText.gameObject.SetActive(false);
    }

    string GenerateName(int index)
    {
        string itemType = null;
        string itemPrefix = ItemInformation.ItemPrefix[Random.Range(0, ItemInformation.ItemPrefix.Length)];
        string itemSuffix = ItemInformation.ItemSuffix[Random.Range(0, ItemInformation.ItemSuffix.Length)];

        switch (index)
        {
            case 0:
                CreatedLoot.SlotTag = itemType = "Chestpiece";
                break;
            case 1:
				CreatedLoot.SlotTag = itemType = "Gloves";
                break;
            case 2:
				CreatedLoot.SlotTag = itemType = "Helm";
                break;
            case 3:
				CreatedLoot.SlotTag = itemType = "Pants";
                break;
            case 4:
				CreatedLoot.SlotTag = itemType = "Boots";
                break;
            case 5:
				CreatedLoot.SlotTag = itemType = "Weapon";
                break;
            default:
				CreatedLoot.SlotTag = itemType = "Index larger than switch";
                break;
        }

        return (itemPrefix + " " + itemType + " of " + itemSuffix).ToString();
    }

	public int RandomIndex(Dictionary<int, Sprite> Dict)
	{
		Random.InitState((int)System.DateTime.Now.Millisecond + System.DateTime.Now.Minute);

		return Random.Range(0, Dict.Count);
	}

}
