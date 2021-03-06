using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AudioManager
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private AudioSource _sfxAudioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType(typeof(AudioManager)) as AudioManager;
        }
        else
        {
            instance = this;
        }
        // Adding AudioSource To the Game Object.
        _sfxAudioSource = gameObject.AddComponent<AudioSource>();
        Debug.Log("Sfx Source Added!");
    }
    
    public void PlaySfx(AudioClip sfxAudioClip)
    {
        Debug.Log("Play Sfx");
        // Sfx Played in OneShot
        _sfxAudioSource.PlayOneShot(sfxAudioClip);
    }
    
    

    public void StopSfx()
    {
        _sfxAudioSource.volume = 0;
    }

    public void PlaySfx()
    {
        _sfxAudioSource.volume = 1;
    }
}
