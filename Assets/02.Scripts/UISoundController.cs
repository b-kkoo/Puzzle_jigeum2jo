using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundController : UIBase
{
    [SerializeField]private Slider backGroundMusicSlider;
    [SerializeField]private Slider effectVolumeSlider;

    private void Start()
    {
        backGroundMusicSlider.onValueChanged.AddListener(ChangeVolume);
        effectVolumeSlider.onValueChanged.AddListener(ChangeEffectVolume);
    }

    public void ChangeVolume(float volume)
    {
        GameManager.instance.SoundManager.ChangeVolume(volume);
    }
    public void ChangeEffectVolume(float volume)
    {
        GameManager.instance.SoundManager.ChangeEffectVolume(volume);
    }
}
