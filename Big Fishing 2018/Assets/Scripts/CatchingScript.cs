using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingScript : MonoBehaviour {

    private const float _SecondsToMinuteConversion = 60f;

    public float FishingBuffer = 10f;
    public float MinimumWait = 0.5f;
    public float MaximumWait = 4.0f;
    public float SpawnPositionY = 0.15f;
    public float SpawnPositionBorder = 0.9f;
    public AudioSource AudioSource;
    public GameObject WaterPlane;

    [HideInInspector]
    public bool FishCatchable = false;

    private float _TimeUntilBite;
    private Vector3 _SpawnLocation;

    private void Awake()
    {
        if (WaterPlane != null)
        {
            MeshRenderer MeshRenderer = WaterPlane.GetComponent<MeshRenderer>();

            if (MeshRenderer != null)
            {
                _SpawnLocation = MeshRenderer.bounds.extents;
            }
        }

        if (AudioSource != null)
        {
            AudioSource = GetComponent<AudioSource>();
        }
    }

    private void OnEnable()
    {
        Random.InitState((int)System.DateTime.Now.Millisecond + System.DateTime.Now.Minute);

        if (WaterPlane != null)
        {
            transform.Translate(-transform.position);
            transform.Translate(FindBobberSpawnLocation());
        }
        else
        {
            Debug.Log("Position defaulted to standard position, please add the plane to [Catching Script]");
        }

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
        float _WhenToBite = Random.Range(MinimumWait, MaximumWait) * _SecondsToMinuteConversion;
        _TimeUntilBite = Time.time + _WhenToBite;
        Debug.Log("Time until fish is active: " + _WhenToBite);
    }

    Vector3 FindBobberSpawnLocation()
    {
        Vector3 Position = WaterPlane.transform.position;
        float RandomX = Random.Range(-_SpawnLocation.x, _SpawnLocation.x) * SpawnPositionBorder;
        float RandomZ = Random.Range(-_SpawnLocation.z, _SpawnLocation.z) * SpawnPositionBorder;
        Vector3 RandomOffset = new Vector3(RandomX, SpawnPositionY, RandomZ);

        Position += RandomOffset;
        
        return Position;
    }
}