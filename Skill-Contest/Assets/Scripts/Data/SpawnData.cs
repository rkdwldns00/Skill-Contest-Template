using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpawnData
{
    public float timer;
    public float timerRandomRange;
    public GameObject[] spawnPool;
}
