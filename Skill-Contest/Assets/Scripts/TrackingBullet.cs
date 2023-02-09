using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBullet : Bullet
{
    Transform player;

    void Awake()
    {
        if (!transform.CompareTag("Player"))
        {
            player = FindObjectOfType<PlayerControll>().transform;
        }
        else
        {
            Victim[] victims = FindObjectsOfType<Victim>();
            float minDistance = 10000;
            foreach(Victim victim in victims)
            {
                if(!victim.CompareTag("Player") && Vector2.Distance(transform.position, victim.transform.position) < minDistance)
                {
                    minDistance = Vector2.Distance(transform.position, victim.transform.position);
                    player = victim.transform;
                }
            }
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        speed += Time.deltaTime * 2;
        //transform.Translate(new Vector2(0, speed) * Time.deltaTime);

        if (timer <= 3 && player != null)
        {
            Vector2 direction = player.position - transform.position;
            float digree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(digree - 90, Vector3.forward), Time.deltaTime * speed / 3f);
        }
    }

    protected override void SetDirection()
    {
        Vector2 direction = player.position - transform.position;
        float digree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
        digree += Random.Range(-90f, 90f);
        transform.rotation = Quaternion.AngleAxis(digree - 90, Vector3.forward);
    }
}
