using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinking : MonoBehaviour
{
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.75)
        {
            GetComponent<Text>().enabled = false;
        }
        if (timer >= 1.5)
        {
            GetComponent<Text>().enabled = true;
            timer = 0;
        }
    }
}
