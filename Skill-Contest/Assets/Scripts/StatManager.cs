using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    public CharacterData CharacterData { get { return characterData; } }

    float[] buffTimer = new float[System.Enum.GetValues(typeof(BuffType)).Length];

    void Start()
    {
        for (int i = 0; i < buffTimer.Length; i++)
        {
            buffTimer[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buffTimer.Length; i++)
        {
            buffTimer[i] -= Time.deltaTime;
        }

        if (GetBuff(BuffType.Flicker))
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 175);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }

    public bool GetBuff(BuffType type)
    {
        return buffTimer[(int)type] > 0;
    }

    public void AddBuff(BuffType type, float time)
    {
        if (time > buffTimer[(int)type])
        {
            buffTimer[(int)type] = time;
        }
    }
}
