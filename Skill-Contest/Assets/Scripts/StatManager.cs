using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    public CharacterData CharacterData { get { return characterData; } }

    float[] buffTimer;

    void Start()
    {
        buffTimer = new float[System.Enum.GetValues(typeof(BuffType)).Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buffTimer.Length; i++)
        {
            buffTimer[i] -= Time.deltaTime;
        }

        Color color = GetComponent<SpriteRenderer>().color;
        if (GetBuff(BuffType.Flicker))
        {
            color.a = 0.5f;
        }
        else
        {
            color.a = 1f;
        }
        GetComponent<SpriteRenderer>().color = color;
    }

    public bool GetBuff(BuffType type)
    {
        return buffTimer[(int)type] > 0;
    }

    public void AddBuff(BuffType type, float time)
    {
        buffTimer[(int)type] = Mathf.Max(time, buffTimer[(int)type]);
    }

    public void ClearBuff(BuffType type)
    {
        buffTimer[(int)type] = 0;
    }
}
