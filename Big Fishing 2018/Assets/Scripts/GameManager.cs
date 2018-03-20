﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int RandomIndex(Dictionary<int, GameObject> Dict)
    {
        Random.InitState((int)System.DateTime.Now.Millisecond + System.DateTime.Now.Minute);

        return Random.Range(0, Dict.Count);
    }
}
