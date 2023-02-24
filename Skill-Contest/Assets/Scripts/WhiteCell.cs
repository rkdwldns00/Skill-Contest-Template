using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCell : Victim
{
    [SerializeField] GameObject[] dropTable;

    protected override void Die()
    {
        Instantiate(dropTable[Random.Range(0, dropTable.Length)], transform.position, Quaternion.identity);
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
