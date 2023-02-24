using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    protected StatManager stat;
    int hp;
    public int Hp { get { return hp; } }

    void Start()
    {
        stat = GetComponent<StatManager>();
        hp = stat.maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        if (stat.IsImmune)
        {
            return;
        }
        if (CompareTag("Player"))
        {
            stat.Immune(1.5f);
        }
        hp -= Mathf.Clamp(damage,0,100);
        if(hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        GameManager.instance.score += stat.score;
        Destroy(gameObject);
    }
}
