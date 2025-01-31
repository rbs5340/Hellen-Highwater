using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Manages the overall game, keeping track of the game state and loading parts of the level when necessary
public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    // Sets up instance of the Game Manager Singleton
    private void Awake()
    {
        if(Instance == null)
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

    // Enum for game state (needs to be public for property to work)
    public enum gameState
    {
        start,
        level,
        pause,
        gameOver
        // Any other states we might need
    };

    // Variable for the current game state
    private gameState state;
    // Property for game state
    public gameState State
    {
        get { return state; }
        set { state = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initializes the game state variable
        state = gameState.start;

        // Call to load level function
        LoadLevel();
    }

    public void LoadLevel()
    {
        // To implement: Function that can activate/reactivate all
        // parts of the level when game begins and level is restarted.
    }
}
