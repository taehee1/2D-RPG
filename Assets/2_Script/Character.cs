using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    //공격
    private bool attackCooldown = true;
    public GameObject attackObj;
    public GameObject heroAttack;

    public GameObject heroSkill1;
    public GameObject skill1Screen;
    public GameObject skill1Hitscan;
    public float skill1Cooltime;
    private bool skill1Cooldown = true;

    public GameObject heroSkill2;
    public float attackSpeed = 3f;
    public AudioClip attackClip;

    //움직임
    public AudioClip jumpClip;

    public float moveSpeed = 4f;
    public float jumpPower = 15f;

    private bool isFacingRight;

    private bool isFloor = true;
    private bool isLadder = false;
    private bool isClimbing = false;
    private float inputVertical;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        skill1Screen = CameraPos.Instance.screen;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
        Skill1();
        ClimbingCheck();
    }

    private void FixedUpdate()
    {
        Climbing();
    }

    private void ClimbingCheck()
    {
        inputVertical = Input.GetAxis("Vertical");
        if (isLadder && Math.Abs(inputVertical) > 0)
        {
            isClimbing = true;
        }
    }

    private void Climbing()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * moveSpeed);
        }
        else
        {
            rb.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    private void Move()
    {
        if (attackCooldown == true && skill1Cooldown == true)
        {
            //왼쪽
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && attackCooldown == true)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                animator.SetBool("Move", true);
                if (isFacingRight) Flip();
            }
            //오른쪽
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && attackCooldown == true)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                animator.SetBool("Move", true);
                if (!isFacingRight) Flip();
            }
            else
            {
                animator.SetBool("Move", false);
            }
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Jump()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space) && attackCooldown == true && skill1Cooldown)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
                audioSource.PlayOneShot(jumpClip);
                isFloor = false;
            }
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.C) && attackCooldown == true)
        {
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(attackClip);

            if (gameObject.name == "Hero(Clone)")
            {
                attackObj.GetComponent<Collider2D>().enabled = true;
                heroAttack.SetActive(true);
                attackCooldown = false;
                Invoke("SetAttackObjInactive", 0.5f);
                Invoke("SetAttackObjActive", 1.1f);
            }
            else
            {
                if (!isFacingRight)
                {
                    GameObject obj = Instantiate(attackObj, transform.position, Quaternion.Euler(0, 180f, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * attackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
                else
                {
                    GameObject obj = Instantiate(attackObj, transform.position, Quaternion.Euler(0, 0, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * attackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
            }
        }
    }

    private void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.X) && attackCooldown == true && skill1Cooldown == true)
        {
            heroSkill1.SetActive(true);
            skill1Screen.SetActive(true);
            skill1Cooldown = false;
            Invoke("Skill1Done", 4f);
        }
    }

    private void Skill1Done()
    {
        heroSkill1.SetActive(false);
        skill1Screen.SetActive(false);
        skill1Cooldown = true;
        skill1Hitscan.GetComponent<Collider2D>().enabled = true;
        Invoke("HitscanOff", 1f);
    }

    private void HitscanOff()
    {
        skill1Hitscan.GetComponent<Collider2D>().enabled = false;
    }

    private void SetAttackObjInactive()
    {
        attackObj.GetComponent<Collider2D>().enabled = false;
    }

    private void SetAttackObjActive()
    {
        heroAttack.SetActive(false);
        attackCooldown = true;
    }
}
