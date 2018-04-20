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
	}
	
    public void OpenLootBox()
    {
        LootBox.SetActive(false);

        _LootIndex = GameManager.Instance.RandomIndex(_LootItemDictionary);

        _LootItemDictionary[_LootIndex].SetActive(true);

        ItemText.gameObject.SetActive(true);

		//ItemText.text = GenerateName(_LootIndex).ToString();

		CreatedLoot.Sprite = _LootItemDictionary[_LootIndex].GetComponent<Image>().sprite;
		ItemText.text = CreatedLoot.Name = GenerateName(_LootIndex).ToString();

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
                itemType = "Breastplate";
                break;
            case 1:
                itemType = "Gauntlets";
                break;
            case 2:
                itemType = "Helm";
                break;
            case 3:
                itemType = "Leggings";
                break;
            case 4:
                itemType = "Boots";
                break;
            case 5:
                itemType = "Sword";
                break;
            default:
                itemType = "Index larger than switch";
                break;
        }

        return (itemPrefix + " " + itemType + " of " + itemSuffix).ToString();
    }
    
}
