using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    private int timer;
    private bool edgeOfPlat;

    // Start is called before the first frame update
    void Start()
    {
        // Centers the "enemy"
        transform.position = Vector3.zero;

        // Sets base speed
        speed = 0.002f;

        // Sets the "timer"
        timer = 0;

        edgeOfPlat = false;
    }

    // Working on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If enemy collides into a pit
        if(collision.gameObject.layer == 8)
        {
            speed *= -1;
            // speed = 0; Doesn't work, need to store speed value as different variable
            timer = 0;
            edgeOfPlat = true;
            Debug.Log("Timer started");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (edgeOfPlat)
        {
            if(timer == 60)
            {
                // When timer reaches 60 continue moving
            }
            else
            {
                // Increment timer
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            edgeOfPlat = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Falls if not on platform (WIP)
        //transform.position = transform.position + new Vector3(0, -0.01f, 0);

        transform.position = transform.position + new Vector3(speed, 0, 0);
    }
}
