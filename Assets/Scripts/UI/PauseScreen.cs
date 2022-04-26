using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private SwipeController swipeController;
    [SerializeField] private BallManager ballManager;

    [Header("UI")]
    [SerializeField] private Canvas pausedCanvas;
    
    [Header("Variable")]
    [SerializeField] private GameObject mainBall;
    [SerializeField] private Rigidbody2D mainBallRb2D;
    public Vector2 storeVelocity;


    [Header("Audio")]
    public bool sfxIsPlaying = true;
    public Image sfxBtn;
    public Sprite sfxOn;
    public Sprite sfxOff;


    private void OnEnable()
    {
        gameEvents.OnGameplayPause += OnGameplayPause;
    }

    public void ShowScreen()
    {
        pausedCanvas.enabled = true;
    }

    public void OnClickContinue()
    {
        gameStateManager.currentGameState = GameState.Gameplay;
        gameStateManager.main?.Invoke();
        gameEvents.PauseOnResume();
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

    public void OnGameplayPause()
    {
        swipeController.enabled = false;
        storeVelocity = mainBallRb2D.velocity;
        ballManager.FreezeBalls();
    }
    

    public void HideScreens()
    {
        pausedCanvas.enabled = false;
    }

    private void OnDisable()
    {
        gameEvents.OnGameplayPause -= OnGameplayPause;
    }
}
