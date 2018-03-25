using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingScript : MonoBehaviour {

    private const float _SecondsToMinuteConversion = 60f;

    public float FishingBuffer = 10f;
    public float MinimumWait = 0.5f;
    public float MaximumWait = 4.0f;
    public AudioSource AudioSource;

    [HideInInspector]
    public bool FishCatchable = false;

    private float _TimeUntilBite;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        RandomTimeCreation();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Time remaining: " + (_TimeUntilBite - Time.time));
        }

		if (Time.time > _TimeUntilBite && Time.time - _TimeUntilBite < FishingBuffer)
        {
            if (AudioSource != null)
            {
                if (!FishCatchable)
                {
                    FishCatchable = true;
                    AudioSource.Play();
                }
            }
        }

        if (Time.time > _TimeUntilBite + FishingBuffer)
        {
            FishCatchable = false;
            RandomTimeCreation();
        }
	}

    void RandomTimeCreation()
    {
        Random.InitState((int)System.DateTime.Now.Millisecond + System.DateTime.Now.Minute);
        float _WhenToBite = Random.Range(MinimumWait, MaximumWait) * _SecondsToMinuteConversion;
        _TimeUntilBite = Time.time + _WhenToBite;
        Debug.Log("Time until fish is active: " + _WhenToBite);
    }
}