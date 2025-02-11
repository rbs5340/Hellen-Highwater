using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Audio Manager Class, Created by Will Doyle
// Contains methods for playing music and SFX, as well as
// fields that determine the volume of the game sounds
public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance;

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
    
    // Single Audio Source that can be used to play multiple sounds
    [SerializeField] private AudioSource source;
    // Determines the volume (0.0f to 1.0f)
    [SerializeField] private float masterVolume;
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;

    // Start is called before the first frame update
    void Start()
    {
        // Volume will need to be hooked up to the sound settings
        masterVolume = 1.0f;
        musicVolume = 1.0f;
        sfxVolume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Empty for now
    }

    // PlaySoundEffect: Takes in the name of the sound file and plays the corresponding sound effect
    // Can play multiple sound effects simultaneously, but it fails to play sound files as soon as the game starts
    public void PlaySoundEffect(string soundEffectName)
    {
        // Stores the selected sound file
        AudioClip soundEffect = Resources.Load("Audio/" + soundEffectName) as AudioClip;

        // Plays the sound file at the appropriate volume
        source.PlayOneShot(soundEffect, masterVolume * sfxVolume);

        // Prints the name of the sound file that is being played
        Debug.Log("Now Playing: " + soundEffectName);
    }

    // PlayMusic: Similar to the above method, will play sound files corresponding to game music
    // Will loop when necessary, and will likely require a method to stop the looping
    public void PlayMusic(string musicName)
    {
        // Not yet implemented
    }

    public void SetMaster(float value)
    {
        masterVolume = value;
    }
}
