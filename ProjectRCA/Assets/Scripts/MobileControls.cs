using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    public float speed = 7;
    public float jumpForce;
    public float moveInput = 0;
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
    bool sprintActive;
    public bool isMoving;
    public bool jumpButtonDown;

    public Joystick joystick;

    void Start()
    {
        initialMoveSpeed = speed;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        //float x = Input.GetAxisRaw("Horizontal");
        //moveInput = Input.GetAxis("Horizontal");
        if (joystick.Horizontal >= 0.2f)
        {
            moveInput = 1;
            isMoving = true;
        }
        else if(joystick.Horizontal <= -0.2f)
        {
            moveInput = -1;
            isMoving = true;
        }
        else
        {
            moveInput = 0;
            isMoving = false;
        }
        if(joystick.Vertical >= 0.2f)
        {
            //Jump();
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 && dir == false)
        {
            Flip();
            dir = true;
        }
        else if (moveInput < 0 && dir == true)
        {
            Flip();
            dir = false;
        }

    }
    void Update()
    {
        
        /*
        if (sprintKeyDown && !sprintActive)
        {
            speed = speed * sprintMultiplier;
            sprintActive = true;
        }
        else if(sprintKeyDown == false && sprintActive)
        {
            speed = initialMoveSpeed;
            sprintActive = false;
        }
        */
        if (grounded == true)
        {
            extraJumps = 0;
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
    public void Jump()
    {
        jumpButtonDown = true;
        if (extraJumps < extraJumpsValue && grounded == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps++;
        }
        else if (grounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    public void JumpButtonUp()
    {
        jumpButtonDown = false;
    }
    public void SprintKeyDown()
    {
        if (grounded)
        {
            if (sprintKeyDown == false)
            {
                sprintKeyDown = true;
                speed = speed * sprintMultiplier;
            }
        }
    }
    public void SprintKeyUp()
    {
        speed = initialMoveSpeed;
        sprintKeyDown = false;
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
            extraJumps = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = true;
            extraJumps = 0;
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
        if (collision.gameObject.tag == "MovingPlatform" || collision.gameObject.tag == "Enemy")
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
    public void MoveLeft()
    {
        moveInput = -1;
    }
    public void MoveRight()
    {
        moveInput = 1;
    }
    public void StopMoving()
    {
        moveInput = 0;
    }
}
