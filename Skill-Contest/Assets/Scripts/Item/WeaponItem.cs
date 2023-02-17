using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item
{
    protected override void Interaction(GameObject player)
    {
        player.GetComponent<PlayerAttacker>().Level += 1;
    }
}
