using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Singleton pattern to make AudioManager accessible from anywhere
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //Variables
    [SerializeField] 
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip healthUp;

    public void PlayHealthUpSound()
    {
        audioSource.PlayOneShot(healthUp);
    }
}
