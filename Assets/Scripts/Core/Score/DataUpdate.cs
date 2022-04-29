using System;
using UnityEngine;
using UnityEngine.UI;

public class DataUpdate : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private Text gameOverhighScoreText;
    [SerializeField] private Text gameOverscoreText;
    [SerializeField] private Text gameplayScoreText;
    private BallMovement ballMovement;
    
    private void OnEnable()
    {
        GameEvents.onGameOver += OnGameOver;
        GameEvents.ResetGame += OnGameRestart;
    }
    
    public void OnGameOver()
    {
        gameOverhighScoreText.text = scoreManager.highScore.ToString();
        gameOverscoreText.text = scoreManager.score.ToString();
        coinManager.SetCoins();
        scoreManager.CheckHighscore();
    }

    public void OnGameRestart()
    {
        scoreManager.ScoreReset();
        gameplayScoreText.text = scoreManager.score.ToString();
    }
}
