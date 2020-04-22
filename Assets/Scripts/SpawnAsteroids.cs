using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
     public Rigidbody2D asteroid;
     private Vector2 lunch;
     private float initSpeed = 1500f;

    // Start is called before the first frame update
    void Update()
    {
        int a = Random.Range(0,100);
        if (a == 1)
        {
            Launch();
            
        }
    }

    // Update is called once per frame
    void Launch()
    {   
        lunch = new Vector2(130, Random.Range(-100,100));
        Rigidbody2D asteroidInstance = Instantiate(asteroid, lunch, Quaternion.identity) as Rigidbody2D;
        Vector2 fwd = new Vector2(-1,0);
        asteroidInstance.AddForce(initSpeed*fwd);
    }
}
