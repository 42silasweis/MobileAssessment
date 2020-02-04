using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlipWithPlayerScript : MonoBehaviour
{
    public float offsetDistance = 0.2f;
    private float moveInput;
    bool hasFlipped;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0 && hasFlipped == false)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            hasFlipped = true;
            
        }
        else if (x < 0 && hasFlipped == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            hasFlipped = false;
        }
    }
}
