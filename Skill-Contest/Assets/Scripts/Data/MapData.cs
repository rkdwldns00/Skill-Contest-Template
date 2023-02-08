using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map Data", menuName = "Scriptable Object/Map Data", order = int.MinValue)]
public class MapData : ScriptableObject
{
    [SerializeField] GameObject backGround;
    public GameObject BackGround { get { return backGround; } }

    [SerializeField] SpawnData[] spawnData;
    public SpawnData[] SpawnData { get { return spawnData; } }

    [SerializeField] GameObject boss;
    public GameObject Boss { get { return boss; } }

    [SerializeField] float time;
    public float Time { get { return time; } }
}
