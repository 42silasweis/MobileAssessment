using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentJump : MonoBehaviour
{
    public float speed = 7;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;

    private bool facingRight = true;

    public bool grounded;

    //public bool isGrounded;
    //public Transform groundCheck;
    //public float checkRadius;
    //public LayerMask whatIsGround;

    public int extraJumps;
    public int extraJumpsValue;

    float initialMoveSpeed;
    public float sprintMultiplier = 2;
    float sprintSpeed;
    public bool sprintKeyDown = false;
    public bool dir;
    Animator anim;

    void Start()
    {
        initialMoveSpeed = speed;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (x > 0 && dir == false)
        {
            Flip();
            dir = true;
        }
        else if(x < 0 && dir == true)
        {
            Flip();
            dir = false;
        }

    }
    void Update()
    {
        if(grounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0 && grounded == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && grounded)
        {
            if (sprintKeyDown == false)
            {
                sprintKeyDown = true;
                speed = speed * sprintMultiplier;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialMoveSpeed;
            sprintKeyDown = false;
        }
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        anim.SetBool("sprint", sprintKeyDown); //make sure to save and surrender
        anim.SetBool("grounded", grounded);
        anim.SetFloat("x", velocity.x);
        anim.SetFloat("y", velocity.y);
        /*
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }*/
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        /*
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = true;
            extraJumps = extraJumpsValue;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = true;
            extraJumps = extraJumpsValue;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = false;
            //jumpCount = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform" || collision.gameObject.tag == "Enemy")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform" || collision.gameObject.tag == "Enemy")
        {
            this.transform.parent = null;
        }
    }
}
