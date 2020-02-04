using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFeetGrounded : MonoBehaviour
{
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
