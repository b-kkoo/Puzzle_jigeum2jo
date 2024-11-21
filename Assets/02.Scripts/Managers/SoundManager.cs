using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] private float musicVolume;
    [SerializeField][Range(0f, 1f)] private float effectVolume;
    
    public Slider backGroundMusicSlider;
    public Slider effectVoulemSlider;
    
    public AudioSource audioSource;
    public AudioSource GameAudioSource;
    public AudioClip mainMusicClip;
    public AudioClip InGameMusicClip;
    
    
    void Awake()
    {
        GameManager.instance.SoundManager = this;
        
        audioSource = GetComponent<AudioSource>();
        GameAudioSource = GameManager.instance.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        if (GameAudioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        audioSource.volume = musicVolume; //볼륨 초기화
        backGroundMusicSlider.value = audioSource.volume;

        GameAudioSource.volume = effectVolume;
        effectVoulemSlider.value = GameAudioSource.volume;
    }

    private void Start()
    {
        PlayMusic(mainMusicClip);
    }

    private void Update()
    {
        ChangeVolume();
    }

    public void ChangeVolume() //Awake에서 받아오는 오디오소스가 null이 뜨는 이유???
    {
        musicVolume = backGroundMusicSlider.value;
        audioSource.volume = musicVolume;
    }

    public void OnStartBtn()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) // 게임씬일때
        {
            PlayMusic(InGameMusicClip);
        }
    }

    public void PlayMusic(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
    }
}
