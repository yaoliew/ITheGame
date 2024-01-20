using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource> ();
        DontDestroyOnLoad(audioSrc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
