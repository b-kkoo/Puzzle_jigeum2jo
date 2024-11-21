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
    
    public AudioSource audioSource;
    public AudioSource GameAudioSource;
    public AudioClip mainMusicClip;
    public AudioClip inGameMusicClip;
    public AudioClip clickSFXClip;
   

    void Start()
    {
        GameManager.instance.SoundManager = this;
        
        audioSource = GetComponent<AudioSource>();
        GameAudioSource = GameManager.instance.gameObject.GetComponent<AudioSource>();
        
        audioSource.volume = musicVolume; //볼륨 초기화

        GameAudioSource.volume = effectVolume;
        
        PlayMusic(mainMusicClip);
        
    }

    public void ChangeVolume(float volume)
    {
        if (audioSource == null)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        audioSource.volume = volume;
    }
    public void ChangeEffectVolume(float volume)
    {
        if (GameAudioSource == null)
        {
            GameAudioSource = GameManager.instance.gameObject.GetComponent<AudioSource>();
        }
        GameAudioSource.volume = volume;
    }

    public void PlayMusic(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
        audioSource.loop = true;
    }

    public void EffectSound(AudioClip Clip)
    {
        GameAudioSource.Stop();
        GameAudioSource.clip = Clip;
        GameAudioSource.PlayOneShot(Clip);
    }
}
