using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public Transform playerTrans;
    public Transform origional;
    public Camera camera;
    float x;
    
    void Start()
    {
        origional.position = transform.position;
        x = camera.orthographicSize;
        Debug.Log(origional.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.cameraActivated == true)
        {
            transform.position = playerTrans.position;
            camera.orthographicSize = 5f;
        }
        if (GameManager.cameraActivated == false)
        {
            transform.position = origional.position;
            camera.orthographicSize = x;
        }
    }
}
