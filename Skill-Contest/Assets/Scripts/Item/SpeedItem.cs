using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Item
{
    protected override void Interaction(GameObject player)
    {
        player.GetComponent<StatManager>().AddBuff(BuffType.SpeedUp,5);
    }
}
