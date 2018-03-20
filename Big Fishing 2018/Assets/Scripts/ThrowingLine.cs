using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingLine : MonoBehaviour
{
    public GameObject FishingLine;
    public CatchingScript FishStatus;

    private float CastBuffer = 0.001f;
    private float _CastBufferTime;
    private bool LineCasted = false;

    private void Awake()
    {
        _CastBufferTime = CastBuffer;

        if (FishingLine != null)
        {
            FishStatus = FishingLine.GetComponent<CatchingScript>();
        }

        if(FishStatus == null)
        {
            Debug.Log("Failed to load FishStatus");
        }
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !LineCasted && (Time.time > _CastBufferTime))
        {
            LineCasted = true;

            if (FishingLine != null)
            {
                FishingLine.SetActive(true);
                Debug.Log("Fishing Line has been thrown");
            }

            else
            {
                Debug.Log("Fishing Line has not been added in inspector");
            }

            _CastBufferTime = Time.time + CastBuffer;
        }

        if(FishingLine != null && LineCasted)
        {
            if (FishStatus != null)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && (Time.time > _CastBufferTime))
                {
                    if (FishStatus.FishCatchable == true)
                    {
                        Debug.Log("Fish was successfully caught!");
                    }

                    Debug.Log("Reeling line back in");

                    FishingLine.SetActive(false);
                    LineCasted = false;

                    _CastBufferTime = Time.time + CastBuffer;
                }
            }
        }
	}
}