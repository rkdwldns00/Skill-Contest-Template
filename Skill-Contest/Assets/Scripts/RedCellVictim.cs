using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCellVictim : Victim
{
    public override void Die()
    {
        GameManager.instance.Pain += 20;
        base.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Die();
        }
    }
}
