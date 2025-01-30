using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller: MonoBehaviour
{
    public float moveSpeed;
    public float jumpStrength;
    public Vector2 position;
    public Vector2 velocity;
    private bool moving;
    private float direction;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        
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
        //velocity.y = rb.velocity.y;
        position += velocity;
        transform.position = position;
        */
        
        direction = Input.GetAxis("Horizontal");
        if (direction > 0f || direction < 0f)
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
        else
        {
            
            rb.velocity = new Vector2(0,rb.velocity.y);
            
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }



    }
}
