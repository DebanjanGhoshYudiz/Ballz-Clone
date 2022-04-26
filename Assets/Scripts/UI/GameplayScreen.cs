using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SwipeController swipeController;
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private GameRestart gameRestart;
    [SerializeField] private BallManager ballManager;

    [Header("UI")]
    [SerializeField] private Canvas gameplayCanvas;
    [SerializeField] private Text gameplayCoinText;
    [SerializeField] private Text gameplayScoreText;
    

    private void OnEnable()
    {
        coinManager.updateCoin += UpdateCoin;
        gameEvents.GameOverReset += OnRestart;
        gameEvents.OnResume += PauseOnResume;
    }
    

    public void OnClickPause()
    {
        gameStateManager.currentGameState = GameState.Pause;
        gameStateManager.main?.Invoke();
        gameEvents.GameplayPause();
    }

    public void UpdateScore()
    {
        scoreManager.score++;
        gameplayScoreText.text = scoreManager.score.ToString();
    }
    
    public void UpdateCoin()
    {
        gameplayCoinText.text = coinManager.noOfCoinsCollected.ToString();
    }

    public void ShowScreen()
    {
        gameplayCoinText.text = coinManager.noOfCoinsCollected.ToString();
        gameplayScoreText.text = scoreManager.score.ToString();
        gameplayCanvas.enabled = true;
        swipeController.enabled = true;
    }

    public void HideScreens()
    {
        gameplayCanvas.enabled = false;
    }

    public void OnRestart()
    {
        gameRestart.OnGameRestart();
    }

    public void PauseOnResume()
    {
        ballManager.UnFreezeBalls();
        ballManager.GiveVelocity();
        swipeController.enabled = true;
    }
    
    private void OnDisable()
    {
        coinManager.updateCoin -= UpdateCoin;
        gameEvents.GameOverReset -= OnRestart;
        gameEvents.OnResume -= PauseOnResume;
    }
}
