using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheet : MonoBehaviour
{
    [SerializeField] GameObject whiteCell;
    [SerializeField] GameObject redCell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameManager.instance.mapIndex = -1;
            GameManager.instance.ChangeMap();
        }else if (Input.GetKeyDown(KeyCode.F2))
        {
            GameManager.instance.mapIndex = 0;
            GameManager.instance.ChangeMap();
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            FindObjectOfType<PlayerAttacker>().Level += 1;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            FindObjectOfType<PlayerControll>().GetComponent<StatManager>().AddBuff(BuffType.Immune, 1000);
            FindObjectOfType<PlayerControll>().GetComponent<StatManager>().AddBuff(BuffType.Flicker, 1000);
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            FindObjectOfType<PlayerControll>().GetComponent<StatManager>().ClearBuff(BuffType.Immune);
            FindObjectOfType<PlayerControll>().GetComponent<StatManager>().ClearBuff(BuffType.Flicker);
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            Victim[] victims = FindObjectsOfType<Victim>();
            foreach (Victim victim in victims)
            {
                if (!victim.CompareTag("Player"))
                {
                    victim.TakeDamage(10000000);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            GameManager.instance.Hp = 100;
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            GameManager.instance.Pain = 0;
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            Instantiate(redCell, Vector3.zero,Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.F10))
        {
            Instantiate(whiteCell, Vector3.zero, Quaternion.identity);
        }
    }
}
