using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
 
    public void BeginGame()
        {
            SceneManager.LoadScene(1);
        }

    public static void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
}
