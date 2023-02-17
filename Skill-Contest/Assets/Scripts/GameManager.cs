using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lastScore;
    public static GameManager instance;
    public static int difficult = 0;
    //[SerializeField] GameObject[] backGroundPrefabs;
    [SerializeField] GameObject playerPrefab;
    //[SerializeField] SpawnData[] spawnData;
    [SerializeField] MapData[] mapData;

    float[] spawnTimer;
    public int mapIndex = -1;
    GameObject backGround;
    float bossSpawnTimer;
    bool isBossSpawned;

    MapData CurrentMapData { get { return mapData[mapIndex]; } }

    int hp = 100;
    public int Hp
    {
        get { return hp; }
        set
        {
            hp = Mathf.Clamp(value, 0, 100);
            if (hp <= 0)
            {
                Debug.Log("ü���������� ���ӿ���");
                GameOver();
            }
        }
    }

    int pain = 10;
    public int Pain
    {
        get { return pain; }
        set
        {
            pain = Mathf.Clamp(value, 0, 100);
            if (pain >= 100)
            {
                Debug.Log("��������������� ���ӿ���");
                GameOver();
            }
        }
    }

    public int Score { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        ChangeMap();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bossSpawnTimer);
        bossSpawnTimer += Time.deltaTime;
        if (bossSpawnTimer <= CurrentMapData.Time)
        {
            for (int i = 0; i < spawnTimer.Length; i++)
            {
                SpawnData[] spawnData = CurrentMapData.SpawnData;
                spawnTimer[i] -= Time.deltaTime;
                if (spawnTimer[i] <= 0)
                {
                    Instantiate(spawnData[i].spawnPool[Random.Range(0, spawnData[i].spawnPool.Length)], new Vector2(Random.Range(-8f, 8f), 6), Quaternion.identity);
                    spawnTimer[i] = spawnData[i].timer + Random.Range(-spawnData[i].timerRandomRange, spawnData[i].timerRandomRange);
                }
            }
        }
        else if (!isBossSpawned)
        {
            isBossSpawned = true;
            Instantiate(CurrentMapData.Boss, new Vector2(0, 10), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        lastScore = Score;
        SceneManager.LoadScene("GameOver");
    }

    public void AddScore(int score)
    {
        this.Score += score * ((6 + difficult) / 6);
    }

    public void ChangeMap()
    {
        if (mapIndex == 1)
        {
            Debug.Log("����ȯ�������� ���ӿ���");
            GameOver();
            return;
        }
        if (backGround != null) { Destroy(backGround); }
        if (mapData.Length - 1 > mapIndex)
        {
            bossSpawnTimer = 0;
            isBossSpawned = false;
            mapIndex += 1;
            spawnTimer = new float[CurrentMapData.SpawnData.Length];
            if (mapIndex == 0)
            {
                Pain = 10;
            }
            else
            {
                Pain = 30;
            }

            int attackLevel = 1;
            if (FindObjectOfType<PlayerAttacker>() != null)
            {
                attackLevel = FindObjectOfType<PlayerAttacker>().Level;
            }
            Instantiate(CurrentMapData.BackGround);
            Victim[] victims = FindObjectsOfType<Victim>();
            foreach (Victim victim in victims)
            {
                Destroy(victim.gameObject);
            }
            Bullet[] bullets = FindObjectsOfType<Bullet>();
            foreach (Bullet b in bullets)
            {
                Destroy(b.gameObject);
            }

            difficult += 1;
            SpawnPlayer(attackLevel);
        }
    }

    void SpawnPlayer(int attackLevel)
    {
        GameObject prefab = Instantiate(playerPrefab, new Vector2(0, -6), Quaternion.identity);
        prefab.GetComponent<PlayerAttacker>().Level = attackLevel;
    }
}
