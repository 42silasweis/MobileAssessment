using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementPLatformer : MonoBehaviour
{
    Rigidbody2D enemyRigidBody2D;
    public float paceSpeed = 1.5f;
    bool grounded;
    bool leftFootGrounded;
    bool rightFootGrounded;
    bool leftSensor;
    bool rightSensor;
    Animator anim;
    bool moveRight = true;
    bool movingRight = true;
    bool movingRight2 = false;
    public float paceDistance = 4.0f;
    Vector3 startPosition;
    bool wentOffEdge;
    bool wentOffEdge2;
    public Vector2 paceDirection;
    Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        leftFootGrounded = gameObject.GetComponentInChildren<EnemyFeetGrounded2>().grounded;
        rightFootGrounded = gameObject.GetComponentInChildren<EnemyFeetGrounded>().grounded;
        leftSensor = gameObject.GetComponentInChildren<LeftSensorScript>().grounded;
        rightSensor = gameObject.GetComponentInChildren<RightSensorScript>().grounded;
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

        float displacement = transform.position.x - startPosition.x;
        if (displacement >= paceDistance)
        {
            paceDirection.x = -displacement;
        }
        paceDirection.Normalize();
        //GetComponent<Rigidbody2D>().velocity = paceDirection * paceSpeed, rb.velocity.y;
        rb.velocity = new Vector2(paceDirection.x * paceSpeed, rb.velocity.y);

        if (rightFootGrounded == false || rightSensor)
        {
            paceDirection.x = -displacement;
        }

        if (leftFootGrounded == false || leftSensor)
        {
            paceDirection.x = -displacement;
        }


        velocity.Normalize();
        GetComponent<Animator>().SetFloat("x", velocity.x);
        anim.SetBool("grounded", grounded);
        anim.SetFloat("x", velocity.x);
        //anim.SetFloat("y", velocity.y);

        float x = velocity.x;
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && !collision.isTrigger)
        {
            grounded = false;
        }
    }
}
