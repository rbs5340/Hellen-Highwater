using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private AudioClip spongebobMeBob;
    [SerializeField] private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        spongebobMeBob = Resources.Load("Audio/Enemy1Walk") as AudioClip;
        source.PlayOneShot(spongebobMeBob, 0.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
