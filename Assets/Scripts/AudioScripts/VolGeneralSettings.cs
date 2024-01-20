using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolGeneralSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    const string MIXER_MUSIC = "MusicVol";
    const string MIXER_SFX = "SFXVol";
    void Awake() 
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetMusicVolume(float val) 
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(val) * 20);
    }

    void SetSFXVolume(float val) {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(val) * 20);
    }
}
