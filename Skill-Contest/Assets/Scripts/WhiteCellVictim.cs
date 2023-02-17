using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCellVictim : Victim
{
    public GameObject[] itemPrefabs;
    bool c = true;

    public override void Die()
    {
        if (c)
        {
            Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], transform.position, Quaternion.identity);
            c = false;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Die();
        }
    }
}
