using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControll2 : MonsterControll
{
    float timer;

    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(1.5f, 2.5f) * (5f / (5f + GameManager.difficult));
            UseAttack(0);
        }
    }
}
