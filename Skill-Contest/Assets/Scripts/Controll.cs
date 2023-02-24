using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    protected StatManager stat;
    protected Attacker attacker;
    [SerializeField] bool isMovingDown;
    [SerializeField] bool isPlayer;
    public bool IsPlayer { get { return isPlayer; } }
    [SerializeField] bool isBoss;
    [SerializeField] bool isAttackAuto;
    [SerializeField] int bulletCount = 1;
    [SerializeField] bool isBurst;
    [SerializeField] float degree;

    float attackTimer;
    float playerTimer;
    float bossDownTimer;
    int bossDirection = 1;

    void Start()
    {
        stat = GetComponent<StatManager>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (isMovingDown)
        {
            transform.position += Vector3.down * stat.moveSpeed * Time.deltaTime;
        }

        if (isPlayer && playerTimer > 1.5f)
        {
            attackTimer -= Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * stat.moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * stat.moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * stat.moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * stat.moveSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Space) && attackTimer <= 0)
            {
                attackTimer = stat.attackDelay;
                attacker.UseAttack(0);
            }
        }
        else if (isPlayer)
        {
            playerTimer += Time.deltaTime;
            transform.position += Vector3.up * stat.moveSpeed * Time.deltaTime;
        }

        if (isBoss)
        {
            if (bossDownTimer < 1)
            {
                bossDownTimer += Time.deltaTime;
                transform.position += Vector3.down * stat.moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(bossDirection, 0, 0) * stat.moveSpeed * Time.deltaTime;
                if (bossDirection == 1 && transform.position.x > 10)
                {
                    bossDirection = -1;
                }
                else if (bossDirection == -1 && transform.position.x < -10)
                {
                    bossDirection = 1;
                }
            }
        }

        if (isAttackAuto)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = stat.attackDelay;
                if (isBurst)
                {
                    StartCoroutine(UseShotGunPlus(1, bulletCount));
                }
                else
                {
                    attacker.UseAttack(0, bulletCount, 20);
                }
            }
        }
    }

    IEnumerator UseShotGunPlus(int min, int max)
    {
        if (min < max)
        {
            attacker.UseAttack(0, min, degree);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(UseShotGunPlus(min + 1, max));
        }
    }

    IEnumerator UseShotGunMinus(int min, int max)
    {
        if (min < max)
        {
            attacker.UseAttack(0, max, degree);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(UseShotGunMinus(min, max - 1));
        }
    }

    private void OnDestroy()
    {
        if (isBoss)
        {
            GameManager.instance.ChangeMap();
        }
    }
}
