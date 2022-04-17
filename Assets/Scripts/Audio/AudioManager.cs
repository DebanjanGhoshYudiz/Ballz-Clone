using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource sfxAudioSource;

    private void Awake()
    {
        instance = this;
        sfxAudioSource = gameObject.AddComponent<AudioSource>();
        Debug.Log("Sfx Source Added!");
    }
    
    public void PlaySfx(AudioClip sfxAudioClip)
    {
        Debug.Log("Play Sfx");
        sfxAudioSource.PlayOneShot(sfxAudioClip);
    }
    
    

    public void StopSfx()
    {
        sfxAudioSource.volume = 0;
    }

    public void PlaySfx()
    {
        sfxAudioSource.volume = 1;
    }
}
