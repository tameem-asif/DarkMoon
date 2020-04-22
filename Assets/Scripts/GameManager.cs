using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool cameraActivated = false;
    public static int totalFuel = 1000;
    public static float currentFuelBeingSpent = 0f;
    public static bool isStartScene = false;
    public static bool isEndScene = false;
    public static bool scene1 = false;
    public static bool scene2 = false;
    public static bool inGame = false;
    public Text ppoints;
    
    void Start()
    {
        //FindObjectOfType<AudioManager>().Play("Start_Screen");
        Physics2D.gravity = new Vector3(0, -4.0F, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Scene meh = SceneManager.GetActiveScene();

        if(FrameUpdate.fuelLeft < 0)
        {
            FrameUpdate.fuelLeft = 0;
        }

        if (meh.name == "Main1")
        {
            GameObject.Find("Canvas/points").GetComponent<Text>().text = "POINTS: " + PlayerMovement.pointsValue.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
        if (meh.name == "StartScreen" && Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(1);
            scene1 = true;
        }
        if(meh.name == "StartScreen")
        {
            isStartScene = true;
        }
        else
        {
            isStartScene = false;
        }
        if(meh.name == "end")
        {
            isEndScene = true;
        }
        else
        {
            isEndScene = false;
        }

        if(meh.name == "Main")
        {
            inGame = true;
        }
        else
        {
            inGame = false;
        }


        if(isEndScene == true)
        {
            if(FindObjectOfType<AudioManager>().isPlaying("End_Screen") == false)
            {
                FindObjectOfType<AudioManager>().Play("End_Screen");
            }
        }
        else
        {
            if(FindObjectOfType<AudioManager>().isPlaying("End_Screen") == true)
            {
                FindObjectOfType<AudioManager>().pause("End_Screen");
            }
        }

        if(meh.name == "Main")
        {
            if(FindObjectOfType<AudioManager>().isPlaying("Main_Sound") == false)
            {
                FindObjectOfType<AudioManager>().Play("Main_Sound");
            }
        }
        else
        {
            if(FindObjectOfType<AudioManager>().isPlaying("Main_Sound") == true)
            {
                FindObjectOfType<AudioManager>().pause("Main_Sound");
            }
        }

        if(isStartScene == true)
        {
            if(FindObjectOfType<AudioManager>().isPlaying("Start_Screen") == false)
            {
                FindObjectOfType<AudioManager>().Play("Start_Screen");
            }
            
        }
        else
        {
            FindObjectOfType<AudioManager>().pause("Start_Screen");
        }

        if(meh.name == "end")
        {
            ppoints.text = "you ended with " + PlayerMovement.pointsValue + " points!";
        }

        if(meh.name != "Main")
        {
            if(FindObjectOfType<AudioManager>().isPlaying("Rocket_Thrust") == true)
            {
                FindObjectOfType<AudioManager>().pause("Rocket_Thrust");
            }

            if(FindObjectOfType<AudioManager>().isPlaying("Low_Fuel") == true)
            {
                FindObjectOfType<AudioManager>().pause("Low_Fuel");
            }
        }
        
        //when level 2 is active, make gravity greater
    }

}
