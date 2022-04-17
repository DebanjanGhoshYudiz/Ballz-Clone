using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    private void Awake()
    {
        instance = this;
        musicAudioSource = gameObject.AddComponent<AudioSource>();
        Debug.Log("AudioSourceAdded!");
        musicAudioSource.loop = true;
        sfxAudioSource = gameObject.AddComponent<AudioSource>();
        Debug.Log("Sfx Source Added!");
    }

    public void PlayMusic(AudioClip musicAudioClip)
    {
        Debug.Log("Play Audio!");
        musicAudioSource.clip = musicAudioClip;
        musicAudioSource.volume = 1f;
        musicAudioSource.Play();
    }

    public void PlaySfx(AudioClip sfxAudioClip)
    {
        Debug.Log("Play Sfx");
        sfxAudioSource.PlayOneShot(sfxAudioClip);
    }
    
    public void PauseMusic()
    {
        musicAudioSource.Pause();
    }

    public void PlayMusic()
    {
        musicAudioSource.Play();
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
