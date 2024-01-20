using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider SFXSlider;
    public Slider MusicSlider;
    public AudioMixer audioMixer;

    void Start() {
        SFXSlider.value = 0.5f;
        MusicSlider.value = 0.5f;
    }
    public void SFXVolume (float vol) {
        //audioMixer.SetFloat("SFXVol", vol);
    }
    public void MusicVolume (float vol) {
        //audioMixer.SetFloat("MusicVol", vol);
    }
}
