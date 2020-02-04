using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int level = 3;
    public int health = 40;

    public Text LevelValue;
    public Text HealthValue;

    private void Start()
    {
        LevelValue.text = "" + level;
        HealthValue.text = "" + health;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void Loadplayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;
        LevelValue.text = "" + level;
        HealthValue.text = "" + health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    public void IncreaseLevel()
    {
        level++;
        LevelValue.text = "" + level;
    }
    public void DecreaseLevel()
    {
        level--;
        LevelValue.text = "" + level;
    }
    public void IncreaseHealth()
    {
        health++;
        HealthValue.text = "" + health;
    }
    public void DecreaseHealth()
    {
        health--;
        HealthValue.text = "" + health;
    }
}
