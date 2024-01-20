using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip click, crateUnlock, letterDestroy, move, victory;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        click = Resources.Load<AudioClip> ("Click_SFX");
        crateUnlock = Resources.Load<AudioClip> ("CrateUnlock_SFX");
        letterDestroy = Resources.Load<AudioClip> ("Letter2_SFX");
        move = Resources.Load<AudioClip> ("Movement_SFX");
        victory = Resources.Load<AudioClip> ("Victory_SFX");

        audioSrc = GetComponent<AudioSource> ();
        DontDestroyOnLoad(audioSrc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case "click" :
                audioSrc.PlayOneShot (click);
                break;
            case "crateUnlock" :
                audioSrc.PlayOneShot (crateUnlock);
                break;
            case "letterDestroy" :
                audioSrc.PlayOneShot (letterDestroy);
                break;
            case "move" :
                audioSrc.PlayOneShot (move);
                break;
            case "victory" :
                audioSrc.PlayOneShot (victory);
                break;
        }
    }
}
