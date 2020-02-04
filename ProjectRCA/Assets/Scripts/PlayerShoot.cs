using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bulletUpgrade;
    GameObject theBullet;
    bool bulletUpgradeActive = false;
    public float bulletSpeed = 10.0f;
    public float bulletLifeTime = 1.0f;
    public float shootDelay = 0.5f;
    public float reduceShootDelay = 0.25f;
    float timer = 0;
    public int ammoCount = 10;
    public int maxAmmo = 10;
    int absoluteMaxAmmo = 25;
    public int capacityIncrease = 5;
    public int ammoBoxAmmount = 2;
    public bool upgradesCarryOver = true;
    public bool bulletsCarryOver = false;
    bool direction;
    int frame;
    public int gunUpgradeLevel;
    GameObject ammoPickup;
    GameObject ammoFullMessage;
    public Text bulletsText;
    float x = 0;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;
        theBullet = bullet1;
        ammoPickup = GameObject.FindGameObjectWithTag("AmmoPickup");
        ammoFullMessage = GameObject.FindGameObjectWithTag("AmmoFull");
        if(PlayerPrefs.GetInt("TripleBulletUpgrade") == 1 && upgradesCarryOver)
        {
            bulletUpgradeActive = true;
            if(gunUpgradeLevel < 3)
            {
                gunUpgradeLevel++;
            }
            
        }
        if(PlayerPrefs.GetInt("IncreasedAmmoCapacityUpgrade") == 1 && upgradesCarryOver)
        {
            maxAmmo += capacityIncrease;
            if (gunUpgradeLevel < 3)
            {
                gunUpgradeLevel++;
            }
        }
        if(PlayerPrefs.GetInt("FasterFireRateUpgrade") == 1 && upgradesCarryOver)
        {
            shootDelay = reduceShootDelay;
            if (gunUpgradeLevel < 3)
            {
                gunUpgradeLevel++;
            }
        }
        if (bulletsCarryOver)
        {
            ammoCount = PlayerPrefs.GetInt("BulletCount");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("BulletCount", ammoCount);
        if (bulletUpgradeActive)
        {
            theBullet = bulletUpgrade;
        }

        direction = gameObject.GetComponent<MobileControls>().dir;
        //float x = Input.GetAxisRaw("Horizontal");
        if (joystick.Horizontal >= 0.2f)
        {
            x = 1;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            x = -1;
        }
        else
        {
            x = 0;
        }
        timer += Time.deltaTime;
        /*
        if (Input.GetButtonDown("Fire1") && timer > shootDelay && ammoCount > 0)
            //if left click do something
        {
            timer = 0;
            GameObject bullet = Instantiate(theBullet, transform.position, Quaternion.identity);
            ammoCount--;
            bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;

            if (x > 0)
             {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
             }

            if (x < 0)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            else if (x == 0 && direction == true)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            }
            else if (x == 0 && direction == false)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            Destroy(bullet, bulletLifeTime);
        }
        */
    }
    public void PewPew()
    {
        if (timer > shootDelay && ammoCount > 0)
        //if left click do something
        {
            timer = 0;
            GameObject bullet = Instantiate(theBullet, transform.position, Quaternion.identity);
            ammoCount--;
            bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;

            if (x > 0)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            }

            if (x < 0)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            else if (x == 0 && direction == true)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            }
            else if (x == 0 && direction == false)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            Destroy(bullet, bulletLifeTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ammo")
        {
            Debug.Log("Ammo trigger detected");
            if (ammoCount < maxAmmo)
            {
                Debug.Log("Getting ammo");
                ammoCount += ammoBoxAmmount;
                bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;
                Destroy(collision.gameObject);
            }            
        }

        if (collision.gameObject.tag == "BulletUpgrade") // Activates the triple bullet when colliding with BulletUpgrade power ups
        {
            if(bulletUpgradeActive == false)
            {
                bulletUpgradeActive = true;
                PlayerPrefs.SetInt("TripleBulletUpgrade", 1);
                if (gunUpgradeLevel < 3)
                {
                    gunUpgradeLevel++;
                }
            }
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "AmmoCapacityUpgrade") // Increases Ammo max capacity when colliding with AmmoCapacityUpgrade power ups
        {
            if(maxAmmo < absoluteMaxAmmo)
            {
                maxAmmo += capacityIncrease;
                bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;
                PlayerPrefs.SetInt("IncreasedAmmoCapacityUpgrade", 1);
                if (gunUpgradeLevel < 3)
                {
                    gunUpgradeLevel++;
                }
            }
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "FireRateUpgrade") // Reduces the shoot delay to the reducedShootDelay value upon colliding with upgrade power up
        {
            if(shootDelay != reduceShootDelay)
            {
                shootDelay = reduceShootDelay;
                PlayerPrefs.SetInt("FasterFireRateUpgrade", 1);
                if (gunUpgradeLevel < 3)
                {
                    gunUpgradeLevel++;
                }
            }
            Destroy(collision.gameObject);
        }
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ammo" && ammoCount < 10)
        {
            ammoCount++;
            Destroy(collision.gameObject);
        }
    } */


    
    private void OnTriggerStay2D(Collider2D collision)
    {

        /*
        if (collision.gameObject.tag == "Ammo" && frame != Time.frameCount)// Messages appear when near ammo and let's you know when you have max ammo and cannot pick up more
        {
            ammoPickup.GetComponent<Text>().enabled = true;
            
            if(Input.GetKeyDown(KeyCode.Mouse1) && ammoCount >= 10)
            {
                ammoFullMessage.GetComponent<Text>().enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1) && ammoCount < 10)
            {
                ammoFullMessage.GetComponent<Text>().enabled = false;
                ammoPickup.GetComponent<Text>().enabled = false;

                ammoCount += ammoBoxAmmount;
                bulletsText.text = "Bullets: " + ammoCount + "/" + maxAmmo;
                Destroy(collision.gameObject);
                frame = Time.frameCount;
            }
        }
        */
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ammo")
        {
            ammoFullMessage.GetComponent<Text>().enabled = false;
            ammoPickup.GetComponent<Text>().enabled = false;
        }

    }
}
