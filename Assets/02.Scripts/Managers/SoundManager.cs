using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume;

    public AudioSource audioSource;
    public AudioClip mainMusicClip;
    
    
    void Awake()
    {
        GameManager.instance.SoundManager = this;
        
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = musicVolume;
    }

    private void Start()
    {
        PlayMusic(mainMusicClip);
    }

    public void PlayMusic(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
    }

    public void ChangeBackGroundMusic(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
    }
}
