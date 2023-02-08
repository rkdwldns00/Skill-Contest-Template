using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    StatManager statManager;

    void Start()
    {
        statManager = GetComponent<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UseAttack(int index)
    {
        GameObject prefab = Instantiate(statManager.CharacterData.Attacks[index], transform.position, Quaternion.identity);
        prefab.tag = transform.tag;
        prefab.GetComponent<DamageDataReciever>().SetDamage(statManager.CharacterData.Damage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (transform.CompareTag("Player"))
        {
            return;
        }
        Victim victim = collision.GetComponent<Victim>();
        if (victim != null && !transform.CompareTag(collision.tag))
        {
            victim.TakeDamage(statManager.CharacterData.Damage / 2);
        }
        else if (collision.GetComponent<GameManager>() != null)
        {
            GameManager.instance.Pain += statManager.CharacterData.Damage / 2;
            Destroy(gameObject);
        }
    }
}
