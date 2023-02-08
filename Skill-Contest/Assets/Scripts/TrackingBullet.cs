using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBullet : Bullet
{
    Transform player;
    float speed = 3;

    void Awake()
    {
        player = FindObjectOfType<PlayerControll>().transform;
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        speed += Time.deltaTime;
        transform.Translate(new Vector2(0, speed) * Time.deltaTime);

        if (speed < 7 && player != null)
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
