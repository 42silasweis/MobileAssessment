using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int level = 1;
    public int health = 4;
    public int lives = 3;
    int initialHealth;
    public Text healthText;
    public Text liveText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Void" || collision.gameObject.tag == "Spike")// || collision.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(collision.gameObject.tag == "TheGirl" && level == 1)
        {
            SceneManager.LoadScene("Level2");
        }
        if (collision.gameObject.tag == "TheGirl" && level == 2)
        {
            SceneManager.LoadScene("Level3");
        }
        if (collision.gameObject.tag == "TheGirl" && level == 3)
        {
            SceneManager.LoadScene("Win");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health--;
            healthText.text = "HP: " + health + "/" + initialHealth;
            if (health < 1)
            {
                lives--;
                liveText.text = "Lives: " + lives;
                PlayerPrefs.SetInt("lives", lives);
                if (lives < 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives");
        initialHealth = health;
        liveText.text = "Lives: " + lives;
        healthText.text = "HP: " + health + "/" + initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
