using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameUpdate : MonoBehaviour
{
    
    static float thrusterSize = 0f;
    public static int thrusterFrame = 0;
    bool grounded = PlayerMovement.grounded;

    static private SpriteRenderer rend;
    //public Sprite[] spriteList;
    public static int fuelLeft = 2000;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rend = GetComponent<SpriteRenderer>();
         bool grounded = PlayerMovement.grounded;
         //Debug.Log(thrusterFrame);
    }
    void FixedUpdate()
    {
       // FrameUpdate.updateFrame(thrusterFrame);
        if (grounded == false) 
        {

            if(Input.GetKey("up") && FrameUpdate.fuelLeft > 0)
            {
                thrusterSizer(0.15f);
               // Debug.Log(thrusterFrame);
            }
            else if(Input.GetKey("down") && FrameUpdate.fuelLeft > 0)
            {
                thrusterSizer(-0.3f);
               // Debug.Log(thrusterFrame);
            }
            else if (Input.GetKey("up") == false && Input.GetKey("down") == false)
            {
                thrusterFrame = 0;
                //Debug.Log(thrusterFrame);
                thrusterSizer(-0.15f);
            }

        }

    }
    static void thrusterSizer (float i)
    {
        if (thrusterSize >= 20)
        {
            thrusterSize = 20;
        }
        if (thrusterSize <= 0)
        {
            thrusterSize = 0;
        }
        if (thrusterSize <=20 && thrusterSize >=0 )
        {
            thrusterSize += i;
            //Debug.Log(thrusterSize);
        }
        
        thrusterFrame = (int)thrusterSize/1;
        FrameUpdate.updateFrame(thrusterFrame);
        fuelLeft -= (int)(thrusterFrame/12); 

        //Player.Play(AnimationClip[thrusterFrame]);
    }
    static void updateFrame (int f)
    {
        if (f == 0)
        {
            GameObject.Find("Player/GFX/A").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/A").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 1)
        {
            GameObject.Find("Player/GFX/B").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/B").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 2)
        {
            GameObject.Find("Player/GFX/C").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/C").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 3)
        {
            GameObject.Find("Player/GFX/D").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/D").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 4)
        {
            GameObject.Find("Player/GFX/E").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/E").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 5)
        {
            GameObject.Find("Player/GFX/F").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/F").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 6)
        {
            GameObject.Find("Player/GFX/G").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/G").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 7)
        {
            GameObject.Find("Player/GFX/H").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/H").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 8)
        {
            GameObject.Find("Player/GFX/I").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/I").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 9)
        {
            GameObject.Find("Player/GFX/J").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/J").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 10)
        {
            GameObject.Find("Player/GFX/K").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/K").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 11)
        {
            GameObject.Find("Player/GFX/L").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/L").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 12)
        {
            GameObject.Find("Player/GFX/M").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/M").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 13)
        {
            GameObject.Find("Player/GFX/N").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/N").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 14)
        {
            GameObject.Find("Player/GFX/O").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/O").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 15)
        {
            GameObject.Find("Player/GFX/P").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/P").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 16)
        {
            GameObject.Find("Player/GFX/Q").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/Q").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 17)
        {
            GameObject.Find("Player/GFX/R").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/R").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 18)
        {
            GameObject.Find("Player/GFX/S").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/S").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (f == 19 || f == 20)
        {
            GameObject.Find("Player/GFX/T").GetComponent<SpriteRenderer>().enabled = true; 
        }
        else
        {
            GameObject.Find("Player/GFX/T").GetComponent<SpriteRenderer>().enabled = false;
        }
    }


}
