using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "Player")
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!transform.CompareTag(collision.tag) && transform.tag != "Untagged")
        {
            Victim victim = collision.GetComponent<Victim>();
            if (victim != null)
            {
                victim.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
