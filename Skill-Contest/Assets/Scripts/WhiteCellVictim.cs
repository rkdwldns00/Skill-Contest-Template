using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCellVictim : Victim
{
    public GameObject[] itemPrefabs;

    public override void Die()
    {
        Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], transform.position, Quaternion.identity);
        base.Die();
    }
}
