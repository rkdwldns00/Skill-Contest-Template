using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Controll>() != null && collision.GetComponent<Controll>().IsPlayer)
        {
            Use(collision.gameObject);
        }
    }

    protected abstract void Use(GameObject player);
}
