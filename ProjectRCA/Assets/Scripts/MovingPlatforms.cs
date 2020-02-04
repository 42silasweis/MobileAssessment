using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float moveDistX = 2.0f;
    public float moveDistY = 2.0f;
    public float flipCoolDown = 1.0f;
    public bool movingInYDir = false;
    public bool currentPos = true;
    public Transform plat1;
    bool posMoved = false;
    bool posMoved2 = false;
    float flipCoolDownTimer = 2.0f;

    void Start()
    {
        flipCoolDownTimer = 3.0f;
    }

    void Update()
    {
        flipCoolDownTimer += Time.deltaTime;
        if (currentPos == true && flipCoolDownTimer > flipCoolDown)
        {
            MoveRight();
            MoveUp();
            posMoved = true;
            posMoved2 = false;
        }
        if (currentPos == false && flipCoolDownTimer > flipCoolDown)
        {            
            MoveLeft();
            MoveDown();
            posMoved2 = true;
            posMoved = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && collision.gameObject.tag == "Player" && !collision.isTrigger && flipCoolDownTimer > flipCoolDown)
        {
            currentPos = !currentPos;
            flipCoolDownTimer = 0;
            Debug.Log("If for lever flip" + flipCoolDownTimer);
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
    }
    void MoveRight()
    {
        if (posMoved == false)
        {
            Vector3 v3 = plat1.transform.position;
            v3.x -= moveDistX;
            plat1.transform.position = v3;
        }
    }
    void MoveLeft()
    {
        if (posMoved2 == false)
        {
            Vector3 v3 = plat1.transform.position;
            v3.x += moveDistX;
            plat1.transform.position = v3;
        }
    }
    void MoveUp()
    {
        if (posMoved == false)
        {
            Vector3 v32 = plat1.transform.position;
            v32.y += moveDistY;
            plat1.transform.position = v32;
        }
    }
    void MoveDown()
    {
        if (posMoved2 == false)
        {
            Vector3 v32 = plat1.transform.position;
            v32.y -= moveDistY;
            plat1.transform.position = v32;
        }
    }
}
