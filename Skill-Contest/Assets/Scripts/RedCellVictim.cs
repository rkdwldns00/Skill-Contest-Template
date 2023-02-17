using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCellVictim : Victim
{
    bool c = true;

    public override void Die()
    {
        if (c)
        {
            GameManager.instance.Pain += 20;
            c = false;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerControll>() != null)
        {
            Die();
        }
        
    }
}
