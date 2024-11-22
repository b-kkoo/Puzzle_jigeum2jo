using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundController : UIBase
{
    [SerializeField]private Slider backGroundMusicSlider;
    [SerializeField]private Slider effectVolumeSlider;
    private SoundManager sound;
    
    private void Start()
    {
        sound = GameManager.instance.SoundManager;
        
        backGroundMusicSlider.value = sound.audioSource.volume;
        effectVolumeSlider.value = sound.GameAudioSource.volume;
        
        backGroundMusicSlider.onValueChanged.AddListener(ChangeVolume);
        effectVolumeSlider.onValueChanged.AddListener(ChangeEffectVolume);
    }

    public void ChangeVolume(float volume)
    {
        sound.ChangeVolume(volume);
    }
    public void ChangeEffectVolume(float volume)
    {
        sound.ChangeEffectVolume(volume);
    }
}
