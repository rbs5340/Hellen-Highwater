using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller: MonoBehaviour
{
    public float moveSpeed;
    public float jumpStrength;
    public Vector2 position;
    public Vector2 velocity;
    private bool moving;
    private float direction;
    private state playerState;


    //Player states for all actions so far. i have a different rising and falling state in case we want to change the gravity to make the platforming feel better,
    enum state
    {
        idle,
        run,
        rise,
        fall,
        damaged,
        wrenchThrow,
        dash

    }
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = state.idle;
        //velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        switch (playerState) {
            case state.idle:
                if(rb.velocity.y > 0)
                {
                    playerState = state.rise;
                }
                else if(rb.velocity.y < 0)
                {
                    playerState = state.fall;
                }
                if (rb.velocity.x != 0)
                {
                    playerState = state.run;
                }

                break;
            case state.run:
                if (rb.velocity.y > 0)
                {
                    playerState = state.rise;
                }
                else if (rb.velocity.y < 0)
                {
                    playerState = state.fall;
                }
                if (rb.velocity.x == 0)
                {
                    playerState = state.idle;
                }
                break;
            case state.rise:
                if (rb.velocity.y == 0)
                {
                    playerState = state.idle;
                }
                else if(rb.velocity.y < 0)
                {
                    playerState = state.fall;
                }
                break;

            case state.fall:
                if (rb.velocity.y == 0)
                {
                    playerState = state.idle;
                }
                break;

            case state.damaged:

            case state.wrenchThrow:

            case state.dash:


            default:
                break;
        }

        direction = Input.GetAxis("Horizontal");
        if (direction > 0f || direction < 0f)
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
        else
        {

            rb.velocity = new Vector2(0, rb.velocity.y);

        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }

        Debug.Log(playerState.ToString());


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
    }
}
