using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] MapData[] mapData;
    [HideInInspector] public int score;
    int pain;
    public int Pain { get { return pain; } }
    int mapIndex = -1;
    GameObject backGround;
    float[] spawnTimer;
    float timer;
    bool isBossSpawned;

    void Start()
    {
        instance = this;
        ChangeMap();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (mapIndex >= 0)
        {
            if (timer <= mapData[mapIndex].time)
            {
                for (int i = 0; i < spawnTimer.Length; i++)
                {
                    spawnTimer[i] -= Time.deltaTime;
                    if (spawnTimer[i] <= 0)
                    {
                        spawnTimer[i] = mapData[mapIndex].spawnData[i].timer + Random.Range(-mapData[mapIndex].spawnData[i].random, mapData[mapIndex].spawnData[i].random);
                        GameObject[] list = mapData[mapIndex].spawnData[i].prefabs;
                        Instantiate(list[Random.Range(0, list.Length)], new Vector3(Random.Range(-10, 10), 6, 0), Quaternion.identity);
                    }
                }
            }
            else if(!isBossSpawned)
            {
                Instantiate(mapData[mapIndex].boss, new Vector3(0, 6, 0), Quaternion.identity);
                isBossSpawned = true;
            }
        }
    }

    public void ChangeMap()
    {
        isBossSpawned = false;
        timer = 0;
        if(mapIndex == -1)
        {
            pain = 10;
        }
        else
        {
            pain = 30;
        }
        if (mapIndex == 1)
        {
            GameOver();
        }
        else
        {
            if (backGround != null)
            {
                Destroy(backGround);
            }
            mapIndex++;
            foreach (Victim victim in FindObjectsOfType<Victim>())
            {
                Destroy(victim.gameObject);
            }
            foreach (Bullet bullet in FindObjectsOfType<Bullet>())
            {
                Destroy(bullet.gameObject);
            }
            spawnTimer = new float[mapData[mapIndex].spawnData.Length];
            Instantiate(mapData[mapIndex].backGround, Vector3.zero, Quaternion.identity);
            GameObject player = Instantiate(playerPrefab, new Vector3(0, -5, 0), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        
    }

    public void AddPain(int value)
    {
        pain += value;
        if(pain >= 100)
        {
            GameOver();
        }
    }
}
