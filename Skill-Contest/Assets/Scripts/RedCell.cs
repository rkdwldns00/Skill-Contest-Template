using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCell : Victim
{
    protected override void Die()
    {
        GameManager.instance.AddPain(stat.damage / 2);
        base.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Controll>() != null && collision.GetComponent<Controll>().IsPlayer)
        {
            Die();
        }
    }
}
