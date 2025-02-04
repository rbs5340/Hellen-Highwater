using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject gameplayObjects;
    public GameObject pauseButton;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        gameplayObjects.SetActive(false);
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        gameplayObjects.SetActive(true);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
