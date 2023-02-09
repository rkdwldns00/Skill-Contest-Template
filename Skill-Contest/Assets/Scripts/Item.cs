using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Interaction(collision.gameObject);
            Destroy(gameObject);
        }
    }

    protected virtual void Interaction(GameObject player)
    {

    }
}
