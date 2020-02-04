using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameTimeHp : MonoBehaviour
{
    public float TimeHp = 180.0f;
    public Text TimeText;
    public float timer;
    float elapsed = 0f;
    private void Start()
    {

    }
    public void Update()
    {
        TimeText.text = "Time: " + TimeHp + "/100";
        TimeText.text = "Time left: " + Mathf.RoundToInt(TimeHp);
        TimeHp -= Time.deltaTime;
        if (TimeHp < 0)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "CorridorOne" 
            || collision.gameObject.tag == "CorridorTwo" || collision.gameObject.tag == "CorridorThree")
        {
            TimeHp-=3;
        }
        else if (collision.gameObject.tag == "Clock")
        {
                TimeHp += 5;
        }
        else if (collision.gameObject.tag == "ThickClock")
        {
                TimeHp += 60;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "CorridorOne" 
            || collision.gameObject.tag == "CorridorTwo" || collision.gameObject.tag == "CorridorThree")
        {
            TimeHp-=5;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            OutputTime();
            void OutputTime()
            {
                Debug.Log(Time.time);
            }

            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "CorridorOne"
                || collision.gameObject.tag == "CorridorTwo" || collision.gameObject.tag == "CorridorThree")
            {
                TimeHp -= 5;
            }
        }
    }
}