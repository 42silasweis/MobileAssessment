using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardModeScript : MonoBehaviour
{
    int hardModeEnabled = 0;


    // Start is called before the first frame update
    void Start()
    {
        hardModeEnabled = PlayerPrefs.GetInt("HardModeEnabled");
        if (hardModeEnabled == 1)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
