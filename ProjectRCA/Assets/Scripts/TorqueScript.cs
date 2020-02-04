using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueScript : MonoBehaviour
{
    public float torque;
    public Rigidbody2D rb;

    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    public int jumpCount = 0;
    public int maxJumps = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float turn = Input.GetAxis("Horizontal");
        Vector3 torque1 = GetComponent<Rigidbody2D>().transform.up;
        rb.AddTorque(torque * -turn);
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)// && grounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
        if (grounded || !grounded)
        {
            jumpCount++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            grounded = false;
            //jumpCount = 0;
        }
    }
}
