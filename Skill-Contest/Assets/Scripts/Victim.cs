using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    StatManager statManager;

    int hp;
    public virtual int Hp
    {
        get { return hp; }
        protected set
        {
            if (statManager != null)
            {
                hp = Mathf.Clamp(value, 0, statManager.CharacterData.Hp);
            }
            else
            {
                hp = Mathf.Max(value, 0);
            }
            if(hp <= 0)
            {
                Die();
            }
        }
    }

    protected virtual void Awake()
    {
        statManager = GetComponent<StatManager>();
    }

    protected virtual void Start()
    {
        if (statManager != null)
        {
            Hp = statManager.CharacterData.Hp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Die()
    {
        if (statManager != null)
        {
            FindObjectOfType<GameManager>().AddScore(statManager.CharacterData.Score);
        }
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (statManager == null || !statManager.GetBuff(BuffType.Immune))
        {
            Hp -= Mathf.Max(damage, 0);
            if(statManager != null && transform.CompareTag("Player"))
            {
                statManager.AddBuff(BuffType.Immune, 1.5f);
                statManager.AddBuff(BuffType.Flicker, 1.5f);
            }
        }
    }
}
