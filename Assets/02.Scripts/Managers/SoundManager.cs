using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float musicVolume;
    [SerializeField][Range(0f, 1f)] private float effectVolume;
    
    public Slider backGroundMusicSlider;
    public Slider effectVoulemSlider;
    
    public AudioSource audioSource;
    public AudioClip mainMusicClip;
    public AudioClip InGameMusicClip;
    
    
    void Awake()
    {
        GameManager.instance.SoundManager = this;
        
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = musicVolume;
        /*backGroundMusicSlider.value = audioSource.volume;
        audioSource.volume = backGroundMusicSlider.value;*/
    }

    private void Start()
    {
        PlayMusic(mainMusicClip);
    }

    /*private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) // 게임씬일때
        {
            ChangeBackGroundMusic(InGameMusicClip);
        }

    }*/

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
