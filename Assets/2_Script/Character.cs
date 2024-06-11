using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private bool attackCooldown = true;
    public GameObject attackObj;
    public GameObject heroAttack;
    public SpriteRenderer heroSprite;
    public float attackSpeed = 3f;
    public AudioClip attackClip;

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
        if (attackCooldown == true)
        {
            //¿ÞÂÊ
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && attackCooldown == true)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                animator.SetBool("Move", true);
                if (isFacingRight) Flip();
            }
            //¿À¸¥ÂÊ
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
            if (Input.GetKeyDown(KeyCode.Space) && attackCooldown == true)
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

            if (gameObject.name == "Warrior(Clone)")
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
