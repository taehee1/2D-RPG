using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    public GameObject attackObj;
    public float attackSpeed = 3f;

    public AudioClip jumpClip;

    public float moveSpeed = 4f;
    public float jumpPower = 15f;

    private bool isFloor = true;


    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    }

    private void FixedUpdate()
    {
    }

    private void Move()
    {
        //����
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            animator.SetBool("Move", true);
            spriteRenderer.flipX = true;
        }
        //������
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            animator.SetBool("Move", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void Jump()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Attack");

            if (spriteRenderer.flipX)
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
