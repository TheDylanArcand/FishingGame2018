using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingLine : MonoBehaviour
{
    public GameObject FishingLine;
    public List<GameObject> FishAvailable;
    public CatchingScript FishStatus;

    private float _CastBuffer = 0.001f;
    private float _CastBufferTime;
    private bool _LineCasted = false;

    private Dictionary<int, GameObject> _FishDictionary = new Dictionary<int, GameObject>();

    private void Awake()
    {
        _CastBufferTime = _CastBuffer;

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
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_LineCasted && (Time.time > _CastBufferTime))
        {
            _LineCasted = true;

            if (FishingLine != null)
            {
                FishingLine.SetActive(true);
                Debug.Log("Fishing Line has been thrown");
            }

            else
            {
                Debug.Log("Fishing Line has not been added in inspector");
            }

            _CastBufferTime = Time.time + _CastBuffer;
        }

        if (FishingLine != null && _LineCasted)
        {
            if (FishStatus != null)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && (Time.time > _CastBufferTime))
                {
                    if (FishStatus.FishCatchable == true)
                    {
                        if ( _FishDictionary != null)
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
                    _LineCasted = false;

                    _CastBufferTime = Time.time + _CastBuffer;
                }
            }
        }
	}
}