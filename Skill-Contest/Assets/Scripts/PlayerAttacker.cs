using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : Attacker
{
    int level = 1;
    public int Level {
        set {
            level = Mathf.Min(5,value);
        }
        get { return level; } 
    }

    public override void UseAttack(int index)
    {
        for (int i = 0; i < Level; i++)
        {
            GameObject prefab = Instantiate(statManager.CharacterData.Attacks[index], transform.position + new Vector3((float)i-Level/2,0,0) / 5, Quaternion.identity);
            prefab.tag = transform.tag;
            if (prefab.GetComponent<DamageDataReciever>())
            {
                prefab.GetComponent<DamageDataReciever>().SetDamage(statManager.CharacterData.Damage);
            }
        }
    }
}
