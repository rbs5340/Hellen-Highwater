using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelenMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpStrength;
    public Vector2 position;
    public Vector2 velocity;
    private bool moving;

    //private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -1 * moveSpeed;
            Debug.Log("LEFT DOWN");
        }
        
        
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = 1 * moveSpeed;
            Debug.Log("RIGHT DONW");
        }

        //Slowly stop the player after inputs are done
        else
        {
            if(Mathf.Abs(velocity.x) > 0)
            {
                velocity.x *= 0.99f;
                Debug.Log("NMOOO");
            }
            
            
        }

        position += velocity;
        transform.position = position;

    }
}
