using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJumps = 2;
    Animator anim;
    float moveX = 0;
    private Rigidbody2D rb;
    public int extraJumps;
    public int extraJumpsValue;


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if(Input.GetButtonDown("Jump") && jumpCount < maxJumps)//&& grounded)
        {
            Jump();
            jumpCount++;
        }
        float x = Input.GetAxisRaw("Horizontal");
        if(x == 0)
        {
            anim.SetInteger("x", 0);
        }
        else
        {
            anim.SetInteger("x", 1);
        }
        if(velocity.y > 0)
        {
            anim.SetInteger("y", 1);
        }
        else if (velocity.y < 0)
        {
            anim.SetInteger("y", -1);
        }
        else
        {
            anim.SetInteger("y", 0);
        }
        if(x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void Jump()
    {
        /*
        if(jumpCount < maxJumps)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
            jumpCount++;
        } */
        if (jumpCount < maxJumps && grounded == false)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumpCount++;
        }
        else if (grounded == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
            anim.SetBool("grounded", grounded);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
            anim.SetBool("grounded", grounded);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = false;
            anim.SetBool("grounded", grounded);
        }
    }
    public void MoveLeft()
    {
        moveX = -1;
    }
    public void MoveRight()
    {
        moveX = 1;
    }
    public void StopMoving()
    {
        moveX = 0;
    }
}
