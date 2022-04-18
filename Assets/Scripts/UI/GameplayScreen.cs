using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private ScoreManager scoreManager;
    
    [Header("UI")]
    [SerializeField] private Canvas gameplayCanvas;
    [SerializeField] private Text gameplayCoinText;
    [SerializeField] private Text gameplayScoreText;

    private void OnEnable()
    {
        coinManager.updateCoin += UpdateCoin;
    }

    private void Start()
    {
        gameplayCoinText.text = coinManager.noOfCoinsCollected.ToString();
    }

    public void OnClickPause()
    {
        gameStateManager.currentGameState = GameState.Pause;
        gameStateManager.main?.Invoke();
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
        gameplayCanvas.enabled = true;
    }

    public void HideScreens()
    {
        gameplayCanvas.enabled = false;
    }

    private void OnDisable()
    {
        coinManager.updateCoin -= UpdateCoin;
    }
}
