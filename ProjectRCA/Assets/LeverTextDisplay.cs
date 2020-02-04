using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeverTextDisplay : MonoBehaviour
{
    int frame;
    public GameObject leverPullMessage;
    GameObject ammoFullMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Lever")// Messages appear when in Lever hitbox range
        {
            leverPullMessage.GetComponent<Text>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            leverPullMessage.GetComponent<Text>().enabled = false;
        }
    }
}
