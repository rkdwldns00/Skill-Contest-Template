using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : Attacker
{
    public int level = 1;

    public override void UseAttack(int index)
    {
        for (int i = 0; i < Mathf.Min(level,5); i++)
        {
            GameObject prefab = Instantiate(statManager.CharacterData.Attacks[index], transform.position + new Vector3(i-level/2,0,0) / 5, Quaternion.identity);
            prefab.tag = transform.tag;
            if (prefab.GetComponent<DamageDataReciever>())
            {
                prefab.GetComponent<DamageDataReciever>().SetDamage(statManager.CharacterData.Damage);
            }
        }
    }
}
