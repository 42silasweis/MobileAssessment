using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float paceSpeed = 1.5f;
    public float paceDistance = 3.0f;
    public Vector2 paceDirection;
    public Vector2 velocity;
    Vector3 startPosition;

    public float paceFrequency = 4.0f;
    public float paceTimer;
    void Start()
    {
        paceTimer = 0;
        Pace();
        startPosition = transform.position;

        
    }
    // This is not nonsense code right?
    void Update()
    {
        paceTimer += Time.deltaTime;
        Pace();
    }


    void Pace() // Pace when no player is nearby and when at home
    {
        Vector3 displacement = transform.position - startPosition;
        float moveX = displacement.x;
        if (displacement.magnitude >= paceDistance)
        {
            displacement = transform.position - startPosition;
            moveX = displacement.x;
            velocity.x = moveSpeed * moveX;
        }
        else
        {
            //paceDirection = -displacement;
            displacement = transform.position - startPosition;
            moveX = -displacement.x;
            velocity.x = moveSpeed * moveX;
            //paceTimer = 0;
        }
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
