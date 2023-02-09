using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryShotItem : Item
{
    protected override void Interaction(GameObject player)
    {
        player.GetComponent<StatManager>().AddBuff(BuffType.SecondaryShot,3);
    }
}
