using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Character Data",menuName ="Scriptable Object/Character Data",order =int.MinValue)]
public class CharacterData : ScriptableObject
{
    [SerializeField] int hp;
    public int Hp
    {
        get { return hp; }
    }

    [SerializeField] int damage;
    public int Damage { get { return damage; } }

    [SerializeField] int score;
    public int Score { get { return score; } }

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField] GameObject[] attacks;
    public GameObject[] Attacks { get { return attacks; } }
}
