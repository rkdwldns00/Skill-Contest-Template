using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControll : Controll
{
    [SerializeField] Slider slider;
    float n = 4.5f;
    float timer;
    float basicAttackCool = 0;
    float missileCool = 0;
    Victim victim;
    StatManager statManager;

    void Start()
    {
        victim = GetComponent<Victim>();
        statManager = GetComponent<StatManager>();
        transform.position += new Vector3(1.3f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)victim.Hp / statManager.CharacterData.Hp;
        if (timer < 3f)
        {
            timer += Time.deltaTime;
            Move(Vector2.down);
        }
        else
        {
            n += Time.deltaTime;
            basicAttackCool -= Time.deltaTime;
            missileCool -= Time.deltaTime;
            transform.position += (Vector3)new Vector2(Mathf.Sin(n) * 2, Mathf.Cos(n * 2)/2) * Time.deltaTime * 3;

            if(basicAttackCool <= 0)
            {
                basicAttackCool = Random.Range(1.2f, 2.2f);
                if (Random.Range(0, 1) == 0)
                {
                    StartCoroutine(ShotGun(Random.Range(0, 1) == 1, 3));
                }
                else
                {
                    UseAttack(3);
                }
            }

            if(missileCool <= 0)
            {
                missileCool = Random.Range(5f, 8f);
                StartCoroutine(Missile(Random.Range(8,12)));
            }
        }
    }

    IEnumerator ShotGun(bool bulletCount ,int n)
    {
        if(bulletCount)
        {
            UseAttack(0);
        }
        else
        {
            UseAttack(1);
        }

        yield return new WaitForSeconds(0.2f);
        if(n > 1)
        StartCoroutine(ShotGun(!bulletCount, n - 1));
    }

    IEnumerator Missile(int count)
    {
        UseAttack(2);
        basicAttackCool += 0.1f;
        yield return new WaitForSeconds(0.05f);
        if(count > 1)
        {
            StartCoroutine(Missile(count - 1));
        }
    }
}
