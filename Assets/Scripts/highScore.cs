using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    public Text score;
    public Text highscore;

    void Start ()
    {
        highscore.text = PlayerPrefs.GetInt("highscore",0).ToString();
    }
    public void UpdateScore()
    {
        int number = Random.Range(1,100); // score
        score.text = number.ToString();
        if(number > PlayerPrefs.GetInt("highscore",0))
        {
            PlayerPrefs.SetInt("highscore", number);
            highscore.text = number.ToString();
        }
        


    }



    void Update()
    {
        
    }
}
