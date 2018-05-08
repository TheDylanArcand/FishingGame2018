using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for throwing the fishing line and the objects able to be caught from fishing
/// </summary>

public class ThrowingLine : MonoBehaviour
{
    public GameObject FishingLine;
    public List<GameObject> FishAvailable;
    public CatchingScript FishStatus;
	public ResourceHolder ResourceHolder;

	private Dictionary<int, GameObject> _FishDictionary;

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
				if(ResourceHolder != null)
				{
					ResourceHolder.ModifyLootBoxes(1);
					ResourceHolder.ModifyEXP(100);
				}
            }
            else
            {
				Debug.Log("No fish currently in dictionary to be caught");
            }
        }

        FishingLine.SetActive(false);
    }
}