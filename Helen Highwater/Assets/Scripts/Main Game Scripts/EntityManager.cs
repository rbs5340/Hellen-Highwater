using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of all objects outside of the player and enemies
public class EntityManager : MonoBehaviour
{
    #region Singleton
    public static EntityManager Instance;

    // Sets up instance of the Game Manager Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Instance already exists");
            Destroy(Instance);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
