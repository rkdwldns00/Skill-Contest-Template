using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : DamageDataReciever
{
    [SerializeField] GameObject bullet;
    [SerializeField] int bulletCount;
    [SerializeField] float digree;

    protected override void SetDirection()
    {
        base.SetDirection();
        float direction = -(digree * (bulletCount - 1) / 2);
        for(int i = 0; i < bulletCount; i++)
        {
            GameObject prefab = Instantiate(bullet, transform.position, Quaternion.identity);
            prefab.tag = transform.tag;
            prefab.GetComponent<DamageDataReciever>().SetDamage(Damage, transform.rotation * Quaternion.AngleAxis(direction, Vector3.forward));
            direction += digree;
        }
        Destroy(gameObject);
    }
}
