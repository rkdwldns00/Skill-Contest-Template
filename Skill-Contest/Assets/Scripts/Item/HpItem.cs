using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : Item
{
    protected override void Interaction(GameObject player)
    {
        GameManager.instance.Hp += 20;
    }
}
