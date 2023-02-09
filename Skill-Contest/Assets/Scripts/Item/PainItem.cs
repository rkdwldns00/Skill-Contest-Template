using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainItem : Item
{
    protected override void Interaction(GameObject player)
    {
        GameManager.instance.Pain -= 20;
    }
}
