using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float monsterHp = 30f;
    public float monsterDmg = 2f;
    public float monsterExp = 3;

    private float moveTime = 1f;
    private float turnTime = 1f;
    private bool isDie = false;

    public float moveSpeed = 3f;

    public GameObject[] itemObj;

    private Animator monsterAnimator;

    private void Start()
    {
        monsterAnimator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        MonsterMove();
    }

    private void MonsterMove()
    {
        if (isDie) return;

        moveTime += Time.deltaTime;

        if (moveTime <= turnTime)
        {
            this.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            turnTime = Random.Range(1, 3);
            moveTime = 0;

            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie) return;

        if (collision.gameObject.tag == "Player")
        {
            monsterAnimator.SetTrigger("Attack");
            GameManager.Instance.PlayerHP -= monsterDmg;
        }

        if (collision.gameObject.tag == "Attack")
        {
            monsterAnimator.SetTrigger("Damage");
            monsterHp -= collision.gameObject.GetComponent<Attack>().damage;

            if (monsterHp <= 0)
            {
                MonsterDie();
            }
        }
    }

    private void MonsterDie()
    {
        isDie = true;
        monsterAnimator.SetTrigger("Die");
        GameManager.Instance.PlayerEXP += monsterExp;

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1.5f);
    }

    private void OnDestroy()
    {
        int itemRandom = Random.Range(0, itemObj.Length);
        if (itemRandom <= itemObj.Length)
        {
            Instantiate(itemObj[itemRandom], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
