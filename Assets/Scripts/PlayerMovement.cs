using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject explosionEffect;

    float angle;
    Vector3 direction;

    public float maxVelocity = 1.2f;
    float minVelocity = 0f;
    public float maxLandSpeed = 15f;
    public float currentMotion;
    public float minSpeed = -100f;
    public float maxSpeed = 100f;
    public float delay = 4f;
    float countDown;

    public Text xVelocity;
    public Text yVelocity;
    public Text crash_land;
    public Text fuelBar;
    public Text points;
    public RawImage xImage;
    public RawImage yImage;
    private Vector3 myRotation;

    float xVel;
    float buffer;

    public static bool grounded = false;
    public static int pointsValue = 0;
    public bool isThrust = false;
    public bool playFuelSound;
    public bool hasLanded = false;
    public bool toNext = false;
    bool hasExploded = false;
    bool toExplode = false;

    void Start()
    {
        countDown = delay;
        hasLanded = false;
        toExplode = false;
        GameManager.cameraActivated = false;
        grounded = false;
        hasExploded = false;
        pointsValue = 0;
        isThrust = false;
        playFuelSound = false;
        FindObjectOfType<AudioManager>().pause("Success_Sound");
        FindObjectOfType<AudioManager>().pause("Crash");
        myRotation = gameObject.transform.rotation.eulerAngles;
        crash_land.text = "";
    }

    void Update()
    {
        if (grounded == false)
        {
            angle = transform.rotation.z;
            angle = Mathf.Sin((angle * Mathf.PI)/180);
            direction.y = Mathf.Asin(angle);
            direction.x = Mathf.Acos(angle);

            xVelocity.text = "HORIZONTAL SPEED: " + Mathf.Abs(Mathf.Round(rb.velocity.x * 50)).ToString();
            yVelocity.text = "VERTICAL SPEED: " + Mathf.Abs(Mathf.Round(rb.velocity.y * 50)).ToString();
            fuelBar.text = "FUEL UNITS: " + FrameUpdate.fuelLeft;
            points.text = "POINTS: " + pointsValue.ToString();
        }
        if (rb.velocity.x > 0)
        {
            xImage.enabled = true;
            xImage.GetComponent<Transform>().localScale = new Vector3(.15f, .15f, 1f);
        }
        else if (rb.velocity.x < 0)
        {
            xImage.enabled = true;
            xImage.GetComponent<Transform>().localScale = new Vector3(.15f, -.15f, 1f);
        }
        else
        {
            xImage.enabled = false;
        }


        if (rb.velocity.y > 0)
        {
            yImage.enabled = true;
            yImage.GetComponent<Transform>().localScale = new Vector3(.15f, -.15f, 1f);
        }
        else if (rb.velocity.y < 0)
        {
            yImage.enabled = true;
            yImage.GetComponent<Transform>().localScale = new Vector3(.15f, .15f, 1f);
        }

        if(Input.GetKey("up") && FrameUpdate.fuelLeft>0)
        {
            if(FindObjectOfType<AudioManager>().isPlaying("Rocket_Thrust") == false)
            {
                FindObjectOfType<AudioManager>().Play("Rocket_Thrust");
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().pause("Rocket_Thrust");
        }

        if (grounded == false)
        {
            if(Input.GetKey("left"))
            {
                myRotation.z = Mathf.Clamp(myRotation.z + 4f, 0f, 180f);
                transform.rotation = Quaternion.Euler(myRotation);
            }

            if(Input.GetKey("right"))
            {
                myRotation.z = Mathf.Clamp(myRotation.z - 4f, 0f, 180f);
                transform.rotation = Quaternion.Euler(myRotation);
            }
            
        
            if(Input.GetKey("up") && rb.velocity.magnitude < maxVelocity && FrameUpdate.fuelLeft > 0)
            {

                if (GameManager.cameraActivated == true)
                {
                    rb.AddRelativeForce(direction / 9);
                    //isThrust = true;
                }
                else
                {
                    rb.AddRelativeForce(direction / 8);
                    //isThrust = true;
                }
                
            }
            else if(Input.GetKey("down"))
            {
                //rb.AddRelativeForce(-direction / 8);
                //isThrust = false;
            }
            else
            {
                //FindObjectOfType<AudioManager>().pause("Rocket_Thrust");
                //isThrust = false;
            }
            

            xVel = (float)rb.velocity.x;

        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        if(grounded == true)
        {
            playFuelSound = false;
        }
        
        if(hasLanded)
        {
            countDown -= Time.deltaTime; 
            if(countDown<=0f)
            {
                SceneManager.LoadScene(2);
            }
        }

        if(hasLanded && !hasExploded && toExplode)
        {
            Explode();
            hasExploded = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(FrameUpdate.fuelLeft <= 500)
        {
            //isThrust = false;
            playFuelSound = true;
        }

        if(playFuelSound == true)
        {
            if(FindObjectOfType<AudioManager>().isPlaying("Low_Fuel") == false)
            {
                FindObjectOfType<AudioManager>().Play("Low_Fuel");
            }
        }
        else
        {
            if(FindObjectOfType<AudioManager>().isPlaying("Low_Fuel") == true)
            {
                FindObjectOfType<AudioManager>().pause("Low_Fuel");
            }
        }

    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    void OnCollisionEnter2D (Collision2D info)
    {
        Debug.Log(info.relativeVelocity.magnitude * 100);
        playFuelSound = false;
        hasLanded = true;

        if (grounded == false)
        {
            if (info.gameObject.name != "LandPad")
            {
                crash_land.text = "YOU CRASHED :(";
                toExplode = true;
                grounded = true;
                isThrust = false;
                playFuelSound = false;
                FindObjectOfType<AudioManager>().Play("Crash");
            }
            else if (((info.relativeVelocity.magnitude*100) < maxLandSpeed) && (info.gameObject.name == "LandPad") && (transform.rotation.eulerAngles.z > 80f) && (transform.rotation.eulerAngles.z < 100f))
            {
                crash_land.text = "YOU LANDED";
                grounded = true;
                isThrust = false;
                playFuelSound = false;
                FindObjectOfType<AudioManager>().Play("Success_Sound");

                if (info.gameObject.tag == "1X")
                {
                    pointsValue += (int)((100/(info.relativeVelocity.magnitude * 100)) * 50);
                }
                else if (info.gameObject.tag == "2X")
                {
                    pointsValue += (int)(((100/(info.relativeVelocity.magnitude * 100)) * 50) * 2);
                }
                else if (info.gameObject.tag == "3X")
                {
                    pointsValue += (int)(((100/(info.relativeVelocity.magnitude * 100)) * 50) * 3);
                }
                else if (info.gameObject.tag == "4X")
                {
                    pointsValue += (int)(((100/(info.relativeVelocity.magnitude * 100)) * 50) * 4);
                }
                else if (info.gameObject.tag == "5X")
                {
                    pointsValue += (int)(((100/(info.relativeVelocity.magnitude * 100)) * 50) * 5);
                }
            }
            else 
            {
                crash_land.text = "YOU CRASHED :(";
                toExplode = true;
                grounded = true;
                isThrust = false;
                playFuelSound = false;
                FindObjectOfType<AudioManager>().Play("Crash");
            }               
        }
    }

    IEnumerator CheckForCrash (Collision2D info)
    {
        if (info.gameObject.name != "LandPad")
        {
            crash_land.text = "YOU CRASHED :(";
            grounded = true;
            isThrust = false;
            playFuelSound = false;
            FindObjectOfType<AudioManager>().Play("Crash");
        }
        yield return new WaitForSeconds (.1f);
    }


}
