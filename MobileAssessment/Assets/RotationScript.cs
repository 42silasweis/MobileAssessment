using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    float moveX = 150;
    public float moveSpeed = 1;
    float rotation;
    bool movingClockWise = false;
    bool movingCounterClockWise = true;
    float timer;
    float rotationInterval = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            Rotate();
        }
    }
    void Rotate()
    {
        if (movingCounterClockWise && !movingClockWise)
        {
            transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime);
            //Debug.Log(transform.rotation.z);
            if (transform.rotation.z >= 0.3420201f && movingCounterClockWise)
            {
                movingClockWise = true;
                movingCounterClockWise = false;
                //Debug.Log("Booleans change");
            }
        }
        else if (movingClockWise && !movingCounterClockWise)
        {
            transform.Rotate(Vector3.forward * -moveSpeed * Time.deltaTime);
            if (transform.rotation.z <= -0.3420201f && movingClockWise)
            {
                movingClockWise = false;
                movingCounterClockWise = true;
            }
        }
    }
}
