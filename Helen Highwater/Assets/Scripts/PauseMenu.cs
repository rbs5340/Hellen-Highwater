using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //Gameplay Objects is an empty game object that all gameplay elements can go into. If this is done then everything will deactivate
    public GameObject gameplayObjects;
    public GameObject pauseButton;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public GameObject textTest;

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
        Time.timeScale = 0f;
        if(gameplayObjects != null)
        {
            gameplayObjects.SetActive(false);
        }
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        if (gameplayObjects != null)
        {
            gameplayObjects.SetActive(true);
        }
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void SetMasterVolume(System.Single value)
    {
        AudioManager.Instance.SetMaster(value);
        textTest.GetComponent<TextMeshProUGUI>().text = (int)(value * 100) + "%";
    }
    public void SetMusicVolume(Slider slider)
    {
        //AudioManager.Instance.musicVolume = slider.value;
        slider.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = slider.value + "%";
    }
    public void SetSfxVolume(Slider slider)
    {
        //AudioManager.Instance.sfxVolume = slider.value;
        slider.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = slider.value + "%";
    }

}
