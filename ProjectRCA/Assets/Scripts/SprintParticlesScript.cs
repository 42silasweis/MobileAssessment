using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintParticlesScript : MonoBehaviour
{
    public float offsetDistance = 0.2f;
    bool sprint;
    bool playerGrounded;
    float timer;
    public float delay = 0.2f;
    public GameObject particle;
    private float moveInput;
    bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moveInput = Input.GetAxis("Horizontal");
        moveInput = gameObject.GetComponentInParent<MobileControls>().moveInput;
        isMoving = gameObject.GetComponentInParent<MobileControls>().isMoving;
        playerGrounded = gameObject.GetComponentInParent<MobileControls>().grounded;
        sprint = gameObject.GetComponentInParent<MobileControls>().sprintKeyDown;
        timer += Time.deltaTime;
        if (isMoving && timer > delay && sprint && playerGrounded && moveInput < 0)
        {
            timer = 0;
            Instantiate(particle, transform.position, transform.rotation);
        }
        if (isMoving && timer > delay && sprint && playerGrounded && moveInput > 0)
        {
            timer = 0;
            Instantiate(particle, transform.position - (Vector3.right * offsetDistance), transform.rotation);
        }
    }
}
