using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy2 : MonoBehaviour
{
    public GameObject deathParticle;
    public float particleLifeTime = 1.0f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(deathParticle, transform.position, transform.rotation);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(deathParticle, transform.position, transform.rotation);

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
