using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moto_controlller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool onGround;
    private bool onGround1;
    public Transform groundCheck;
    public float checkRadious;
    public Transform groundCheck2;
    public float checkRadious2;
    public LayerMask whatIsGround;
    public Animator animator;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onGround1 = Physics2D.OverlapCircle(groundCheck.position, checkRadious, whatIsGround);
        onGround = Physics2D.OverlapCircle(groundCheck2.position, checkRadious2, whatIsGround);
    }
    
    public void Speed()
    {
        speed = 30;
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;


    }
    void FixedUpdate()
    {


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(moveInput != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        if (facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();
        }

        if (onGround == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetBool("jump", true);

            }


        }
        else if (onGround1 == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.up * jumpForce;

            }
        }

    }
    private void Update()
    {

        onGround1 = Physics2D.OverlapCircle(groundCheck.position, checkRadious, whatIsGround);
        onGround = Physics2D.OverlapCircle(groundCheck2.position, checkRadious2, whatIsGround);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (onGround == true)
        {
            animator.SetBool("jump", false);
            if (Input.GetButtonDown("Jump"))
            {   
                rb.velocity = Vector2.up * jumpForce;
                animator.SetBool("jump", true);
            }


        }
        else if (onGround1 == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.up * jumpForce;

            }
        }

    }

}