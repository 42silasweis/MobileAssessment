using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBulletParentLifetime : MonoBehaviour
{
    public float lifeTime = 5.0f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
