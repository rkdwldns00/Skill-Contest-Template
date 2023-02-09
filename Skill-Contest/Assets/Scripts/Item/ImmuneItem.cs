using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneItem : Item
{
    protected override void Interaction(GameObject player)
    {
        player.GetComponent<StatManager>().AddBuff(BuffType.Immune, 3);
        player.GetComponent<StatManager>().AddBuff(BuffType.Flicker, 2.5f);
    }
}
