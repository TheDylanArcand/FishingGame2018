using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootboxHandler : MonoBehaviour
{
    public GameObject LootBox;
    public List<GameObject> LootItem;
    public float LootBuffer = 0.001f;


    private bool _LootOpened = false;
    private int _LootIndex;
    private float _LootBufferTime;
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
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (LootBox != null && _LootItemDictionary != null && !_LootOpened && Time.time > _LootBufferTime)
            {
                LootBox.SetActive(false);

                _LootIndex = GameManager.instance.RandomIndex(_LootItemDictionary);

                _LootItemDictionary[_LootIndex].SetActive(true);

                _LootOpened = true;

                _LootBufferTime = Time.time + LootBuffer;
            }

            if (LootBox!= null && _LootItemDictionary != null && _LootOpened && Time.time > _LootBufferTime)
            {
                LootBox.SetActive(true);

                _LootItemDictionary[_LootIndex].SetActive(false);

                _LootOpened = false;

                _LootBufferTime = Time.time + LootBuffer;
            }
        }
	}
}
