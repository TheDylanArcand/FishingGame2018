using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingLine : MonoBehaviour
{
    public GameObject FishingLine;
    public List<GameObject> FishAvailable;
    public CatchingScript FishStatus;

    private Dictionary<int, GameObject> _FishDictionary = new Dictionary<int, GameObject>();

    private void Awake()
    {
        if (FishAvailable != null)
        {
            for (int i = 0; i < FishAvailable.Count; i++)
            {
                _FishDictionary.Add(i, FishAvailable[i]);
            }
        }

        if (FishingLine != null)
        {
            FishStatus = FishingLine.GetComponent<CatchingScript>();
        }

        if (FishStatus == null)
        {
            Debug.Log("Failed to load FishStatus");
        }
    }

    public void CastFishingLine()
    {
        if (FishingLine != null)
        {
            FishingLine.SetActive(true);
            Debug.Log("Fishing Line has been thrown");
        }

        else
        {
            Debug.Log("Fishing Line has not been added in inspector");
        }
    }

    public void ReelFishingLine()
    {
        if (FishStatus.FishCatchable == true)
        {
            if (_FishDictionary != null)
            {
                Debug.Log("Fish #" + GameManager.Instance.RandomIndex(_FishDictionary) + " was successfully caught!");
            }
            else
            {
                Debug.Log("Fish was successfully caught! Also put the fish in");
            }
        }

        Debug.Log("Reeling line back in");

        FishingLine.SetActive(false);
    }
}