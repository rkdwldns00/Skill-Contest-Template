using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : DamageDataReciever
{
    [SerializeField] float speed;
    [SerializeField] bool isPearcingShot;
    float timer;
    [SerializeField] float destroyTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(timer >= destroyTimer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Victim victim = collision.GetComponent<Victim>();
        if (victim != null && !transform.CompareTag(collision.tag))
        {
            victim.TakeDamage(Damage);
            if (!isPearcingShot)
            {
                Destroy(gameObject);
            }
        }
    }
}
