using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVictim : Victim
{
    GameManager gameManager;

    public override int Hp {
        get => gameManager.Hp;
        protected set => gameManager.Hp = value;
    }

    protected override void Awake()
    {
        base.Awake();
        gameManager = FindObjectOfType<GameManager>();
    }
}
