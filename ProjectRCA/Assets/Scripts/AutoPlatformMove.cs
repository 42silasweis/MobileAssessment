using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlatformMove : MonoBehaviour
{
    public float moveXSpeed = 3f;
    public float moveYSpeed = 3f;
    bool moveRight = true;
    bool moveUp = true;
    bool moveUpAndRight = true;
    public float paceDistance = 3.0f;
    Vector3 startPosition;
    public bool movesUpAndRight;
    public bool movesUpAndDown;

    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        Vector3 displacement = transform.position - startPosition;
        if (displacement.magnitude >= paceDistance)
        {
            moveRight = !moveRight;
            moveUp = !moveUp;
            moveUpAndRight = !moveUpAndRight;
        }
        /*
        if (transform.position.x > 4f)
        {
            moveRight = false;
        }
        if (transform.position.x > -4f)
        {
            moveRight = true;
        }
        */

        if (moveRight && movesUpAndRight == false && movesUpAndDown == false)
        {
            transform.position = new Vector2(transform.position.x + moveXSpeed * Time.deltaTime, transform.position.y);
            Debug.Log("If moveRight");
        }
        else if(movesUpAndRight == false && moveRight == false && movesUpAndDown == false)
        {
            transform.position = new Vector2(transform.position.x - moveXSpeed * Time.deltaTime, transform.position.y);
            Debug.Log("Else if MoveRight");
        }

        if (moveUp && movesUpAndDown && movesUpAndRight == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveYSpeed * Time.deltaTime);
            Debug.Log("If MoveUp");
        }
        else if (movesUpAndRight == false && moveUp == false && movesUpAndDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveYSpeed * Time.deltaTime);
            Debug.Log("Else if moveUp");
        }

        if (moveUpAndRight && movesUpAndRight)
        {
            transform.position = new Vector2(transform.position.x + moveYSpeed * Time.deltaTime, transform.position.y + moveXSpeed * Time.deltaTime);
            Debug.Log("If moveUpAndRight");
        }
        else if (moveUpAndRight == false && movesUpAndRight)
        {
            transform.position = new Vector2(transform.position.x - moveYSpeed * Time.deltaTime, transform.position.y - moveXSpeed * Time.deltaTime);
            Debug.Log("Else if moveUpAndRight");
        }

    }
}
