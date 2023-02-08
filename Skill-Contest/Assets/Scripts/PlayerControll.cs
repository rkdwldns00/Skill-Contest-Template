using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : Controll
{
    float attackCool;

    // Update is called once per frame
    void Update()
    {
        attackCool-=Time.deltaTime;
        Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (attackCool <= 0 && Input.GetKey(KeyCode.Space))
        {
            attackCool = 0.1f;
            UseAttack(0);
        }
    }
}
