using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private SwipeController swipeController;
    [SerializeField] private BallManager ballManager;

    [Header("UI")]
    [SerializeField] private Canvas pausedCanvas;
    
    [Header("Variable")]
    [SerializeField] private GameObject mainBall;
    [SerializeField] private Rigidbody2D mainBallRb2D;
    


    [Header("Audio")]
    public bool sfxIsPlaying = true;
    public Image sfxBtn;
    public Sprite sfxOn;
    public Sprite sfxOff;


    
    
    public void OnClickContinue()
    {
        gameStateManager.currentGameState = GameState.Gameplay;
        gameStateManager.main?.Invoke(Screens.GameplayScreen);
        GameEvents.PauseOnResume();
    }

    public void OnClickMainMenu()
    {
        gameStateManager.currentGameState = GameState.MainMenu;
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
