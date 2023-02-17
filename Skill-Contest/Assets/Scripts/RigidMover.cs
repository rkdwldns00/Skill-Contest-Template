using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMover : Mover
{
    Rigidbody2D rigid;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 direction)
    {
        if(rigid == null)
        {
            return;
        }

        float speed = 1;
        if (statManager != null)
        {
            speed = statManager.CharacterData.MoveSpeed;
        }
        if (statManager != null && statManager.GetBuff(BuffType.SpeedUp))
        {
            speed *= 2f;
        }
        rigid.velocity = direction.normalized * speed;
    }
}
