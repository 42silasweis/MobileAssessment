using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgradeLevelScript : MonoBehaviour
{
    int gunLevel;
    public GameObject silverGun;
    public GameObject goldenGun;
    public GameObject bananaGun;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        silverGun.GetComponent<SpriteRenderer>().enabled = false;
        goldenGun.GetComponent<SpriteRenderer>().enabled = false;
        bananaGun.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        gunLevel = gameObject.GetComponentInParent<PlayerShoot>().gunUpgradeLevel;
        if(gunLevel == 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if(gunLevel == 1)
        {
            silverGun.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            silverGun.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(gunLevel == 2)
        {
            goldenGun.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            goldenGun.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(gunLevel == 3)
        {
            bananaGun.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            bananaGun.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
