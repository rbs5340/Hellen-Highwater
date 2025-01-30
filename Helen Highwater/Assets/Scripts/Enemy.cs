using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Working on collision
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");
    }

    // Update is called once per frame
    void Update()
    {
        // Falls if not on platform (WIP)
        //transform.position = transform.position + new Vector3(0, -0.01f, 0);

        transform.position = transform.position + new Vector3(0.01f, 0, 0);
    }
}
