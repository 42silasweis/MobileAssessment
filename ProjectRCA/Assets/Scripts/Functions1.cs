using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions1 : MonoBehaviour
{


    void Start()
    {
        simpleFunction();
        int damage = DamageCalc(42, 13);
        DamageCalc(23, 4, true);
    }
    void simpleFunction()
    {
        Debug.Log("Yo");
    } 

    public int DamageCalc(int damage, int armor)
    {
        Debug.Log("you deal" + (damage - armor) + "damage");
        return damage - armor;
    }
    public int DamageCalc(int damage, int armor, bool crit)
    {
        Debug.Log("you deal" + (damage - armor) + "damage");
        return damage - armor;
    }
}
