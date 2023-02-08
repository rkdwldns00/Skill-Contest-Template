using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControll : Controll
{
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            UseAttack(0);
            timer = 1;
        }
        Move(Vector2.down);
    }
}
