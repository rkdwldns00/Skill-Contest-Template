using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map Data", menuName = "Scriptable Object/Map Data", order = int.MinValue)]
public class MapData : ScriptableObject
{
    public SpawnData[] spawnData;
    public GameObject backGround;
    public GameObject boss;
    public float time;
}
