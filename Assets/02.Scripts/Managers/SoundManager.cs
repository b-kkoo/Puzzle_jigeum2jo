using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] private float musicVolume = 0.5f;
    [SerializeField][Range(0f, 1f)] private float effectVolume = 0.5f;
    
    public Slider backGroundMusicSlider;
    public Slider effectVolumeSlider;
    
    public AudioSource audioSource;
    public AudioSource GameAudioSource;
    public AudioClip mainMusicClip;
    public AudioClip InGameMusicClip;
   

    void Start()
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
            GameAudioSource = GameManager.instance.gameObject.AddComponent<AudioSource>();
        }
        
        audioSource.volume = musicVolume; //볼륨 초기화
        backGroundMusicSlider.value = audioSource.volume;

        GameAudioSource.volume = effectVolume;
        effectVolumeSlider.value = GameAudioSource.volume;
        
        PlayMusic(mainMusicClip);
    }

    public void ChangeVolume(float volume) //Awake에서 받아오는 오디오소스가 null이 뜨는 이유???
    {
        if (audioSource == null)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        audioSource.volume = volume;
        //musicVolume = backGroundMusicSlider.value;
    }
    public void ChangeEffectVolume(float volume) //Awake에서 받아오는 오디오소스가 null이 뜨는 이유???
    {
        effectVolume = volume;
    }

    public void PlayMusic(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
        audioSource.loop = true;
    }
}
