using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles all inputs made by the player (Left blank for now since Erika is handling inputs for now) 
public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager Instance;

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
