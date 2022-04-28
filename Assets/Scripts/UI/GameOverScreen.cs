using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text scoreText;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SwipeController swipeController;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private BallManager ballManager;

    

    public void ShowScreen()
    {
        gameOverCanvas.enabled = true;
        highScoreText.text = scoreManager.highScore.ToString();
        scoreText.text = scoreManager.score.ToString();
        coinManager.SetCoins();
        scoreManager.CheckHighscore();
        scoreManager.ScoreReset();
    }

    public void OnClickRestart()
    {
        gameStateManager.currentGameState = GameState.Gameplay;
        gameStateManager.main?.Invoke();
        GameEvents.GameOverResetContent();
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickExit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    

    public void HideScreens()
    {
        gameOverCanvas.enabled = false;
    }
    
}
