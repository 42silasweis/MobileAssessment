using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGunUpgrades : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("TripleBulletUpgrade", 0);
        PlayerPrefs.SetInt("IncreasedAmmoCapacityUpgrade", 0);
        PlayerPrefs.SetInt("FasterFireRateUpgrade", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
