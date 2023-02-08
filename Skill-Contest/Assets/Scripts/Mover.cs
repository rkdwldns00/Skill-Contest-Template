using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    StatManager statManager;

    void Start()
    {
        statManager = GetComponent<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        float speed = 1;
        if (statManager != null)
        {
            speed = statManager.CharacterData.MoveSpeed;
        }

        transform.position = (Vector2)transform.position + direction.normalized * speed * Time.deltaTime;
    }
}
