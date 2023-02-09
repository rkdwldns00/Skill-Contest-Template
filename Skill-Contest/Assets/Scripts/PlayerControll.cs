using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : Controll
{
    StatManager statManager;
    float attackCool;
    float secondaryCool;
    float timer;

    private void Start()
    {
        statManager = GetComponent<StatManager>();
        GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer < 1.5f)
        {
            Move(Vector2.up);
            return;
        }
        GetComponent<Collider2D>().enabled = true;
        attackCool-=Time.deltaTime;
        secondaryCool-=Time.deltaTime;
        Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (attackCool <= 0 && Input.GetKey(KeyCode.Space))
        {
            attackCool = 0.1f;
            UseAttack(0);
        }
        if(secondaryCool <= 0 && Input.GetKey(KeyCode.Space) && statManager.GetBuff(BuffType.SecondaryShot))
        {
            secondaryCool = 0.3f;
            UseAttack(1);
        }
    }
}
