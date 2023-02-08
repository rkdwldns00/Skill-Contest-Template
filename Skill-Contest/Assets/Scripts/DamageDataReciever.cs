using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageDataReciever : MonoBehaviour
{
    int damage;
    public int Damage
    {
        get { return damage; }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
        SetDirection();
    }

    protected virtual void SetDirection()
    {
        if (transform.CompareTag("Player"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        { 
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
