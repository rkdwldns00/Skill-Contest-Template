using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controll : MonoBehaviour
{
    Attacker attacker;
    Mover mover;

    protected virtual void Awake()
    {
        attacker = GetComponent<Attacker>();
        mover = GetComponent<Mover>();
    }

    protected void UseAttack(int index)
    {
        if (mover != null)
        {
            attacker.UseAttack(index);
        }
    }

    protected void Move(Vector2 direction)
    {
        if (mover != null)
        {
            mover.Move(direction);
        }
    }

    protected void Move(float x,float y)
    {
        Move(new Vector2(x, y));
    }
}
