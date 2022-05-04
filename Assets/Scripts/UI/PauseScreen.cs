using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [Header("Audio")]
    public bool sfxIsPlaying = true;
    public Image sfxBtn;
    public Sprite sfxOn;
    public Sprite sfxOff;


    
    
    public void OnClickContinue()
    {
        UIManager.instance.ShowScreen(Screens.GameplayScreen);
        GameEvents.PauseOnResume();
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    

    public void OnClickSfxSound()
    {
        if (!sfxIsPlaying)
        {
            AudioManager.instance.PlaySfx();
            sfxBtn.sprite = sfxOn;
            sfxIsPlaying = true;
        }
        else if (sfxIsPlaying)
        {
            AudioManager.instance.StopSfx();
            sfxBtn.sprite = sfxOff;
            sfxIsPlaying = false;
        }
    }
    
    
    
    
}
