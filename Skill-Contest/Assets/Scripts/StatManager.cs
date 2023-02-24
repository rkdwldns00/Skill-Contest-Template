using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int maxHp;
    public float moveSpeed;
    public float bulletSpeed;
    public int damage;
    public float attackDelay;
    public GameObject[] attacks;
    public int score;

    SpriteRenderer render;
    float immuneTimer;
    public bool IsImmune { get { return immuneTimer > 0; } }

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        immuneTimer -= Time.deltaTime;
        Color color = render.color;
        if (immuneTimer >= 0.5f)
        {
            color.a = 0.5f;
        }
        render.color = color;
    }

    public void Immune(float time)
    {
        immuneTimer = time;
    }
}
