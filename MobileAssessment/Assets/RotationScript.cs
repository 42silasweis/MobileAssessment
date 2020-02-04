using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    float moveX = 150;
    public float moveSpeed = 1;
    float rotation;
    bool movingClockWise;
    bool movingCounterClockWise;
    float timer;
    float rotationInterval = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateLeft();
        }
        rotation = GetComponent<Rigidbody2D>().rotation;
        
        GetComponent<Rigidbody2D>().rotation = moveX + moveSpeed * Time.deltaTime;
    }
    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * -90);
    }
}
