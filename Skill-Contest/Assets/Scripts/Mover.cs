using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    protected StatManager statManager;

    protected virtual void Start()
    {
        statManager = GetComponent<StatManager>();
    }

    public virtual void Move(Vector2 direction)
    {
        float speed = 1;
        if (statManager != null)
        {
            speed = statManager.CharacterData.MoveSpeed;
        }
        if (statManager != null && statManager.GetBuff(BuffType.SpeedUp))
        {
            speed *= 2f;
        }
        if (CompareTag("Monster"))
        {
            speed *= (3f+GameManager.difficult) / 3;
        }

        transform.position = (Vector2)transform.position + direction.normalized * speed * Time.deltaTime;
    }
}
