using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    StatManager stat;

    void Start()
    {
        stat = GetComponent<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UseAttack(int index, float degree)
    {
        GameObject prefab = Instantiate(stat.attacks[index], transform.position, Quaternion.identity);
        prefab.transform.Rotate(new Vector3(0, 0, degree));
        prefab.tag = gameObject.tag;
        prefab.GetComponent<Bullet>().speed = stat.bulletSpeed;
        prefab.GetComponent<Bullet>().damage = stat.damage;
    }

    public void UseAttack(int index)
    {
        UseAttack(index, 0);
    }

    public void UseAttack(int index, int howMany, float degree)
    {
        float n = degree * (howMany - 1) / 2;
        for (int i = 0; i < howMany; i++)
        {
            UseAttack(index, n);
            n -= degree;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CompareTag(collision.tag) && !CompareTag("Player"))
        {
            Victim victim = collision.GetComponent<Victim>();
            if (victim != null)
            {
                victim.TakeDamage(stat.damage / 2);
                //Destroy(gameObject);
            }
        }
    }
}
