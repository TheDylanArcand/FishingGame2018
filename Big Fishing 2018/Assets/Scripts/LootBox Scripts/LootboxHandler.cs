using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootboxHandler : MonoBehaviour
{
    public GameObject LootBox;
    public List<GameObject> LootItem;
    public Text ItemText;
	public ItemScript CreatedLoot;
	public InventoryScript ItemTransferer;

	public Text LootboxText;
	public ResourceHolder ResourceHolder;

	private string[] _ItemPrefix =
    {
        "Fast",
        "Strong",
        "Beefy",
        "Searing",
        "Crystal",
        "Limestone",
        "Spooky",
        "Scary",
        "Skeleton"
    };

    private string[] _ItemSuffix =
    {
        "Insanity",
        "Flame",
        "Health",
        "Resistance",
        "Life",
        "Destiny",
        "Pain",
        "Nature"
    };
    
    private int _LootIndex;
    private Dictionary<int, GameObject> _LootItemDictionary = new Dictionary<int, GameObject>();

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

        if (_LootItemDictionary != null)
        {
            Debug.Log("There are things in LootItemDictionary");
        }

		LootboxText.text = "Lootboxes: " + ResourceHolder.GetLootBoxCount();
	}
	
    public void OpenLootBox()
    {
        LootBox.SetActive(false);

        _LootIndex = GameManager.Instance.RandomIndex(_LootItemDictionary);

        _LootItemDictionary[_LootIndex].SetActive(true);

        ItemText.gameObject.SetActive(true);

		CreatedLoot.Sprite = _LootItemDictionary[_LootIndex].GetComponent<Image>().sprite;
		ItemText.text = CreatedLoot.Name = GenerateName(_LootIndex).ToString();
		ItemTransferer.AddItem(CreatedLoot);

		ResourceHolder.ModifyLootBoxes(-1);
		LootboxText.text = "Lootboxes: " + ResourceHolder.GetLootBoxCount();

	}

    public void CloseLootBox()
    {
        LootBox.SetActive(true);

        _LootItemDictionary[_LootIndex].SetActive(false);

        ItemText.gameObject.SetActive(false);
    }

    string GenerateName(int index)
    {
        string itemType = "null";
        string itemPrefix = _ItemPrefix[Random.Range(0, _ItemPrefix.Length)];
        string itemSuffix = _ItemSuffix[Random.Range(0, _ItemSuffix.Length)];

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
    
}
