using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Rigidbody2D mainBallRb2D;
    [SerializeField] private SwipeController swipeController;
    [SerializeField] private BallManager ballManager;
    public Vector2 storeVelocity;
    
    [Header("UI")]
    [SerializeField] private Canvas gameplayCanvas;
    [SerializeField] private Text gameplayCoinText;
    [SerializeField] private Text gameplayScoreText;
    

    private void OnEnable()
    {
        coinManager.updateCoin += UpdateCoin;
    }
    

    public void OnClickPause()
    {
        swipeController.enabled = false;
        storeVelocity = mainBallRb2D.velocity;
        ballManager.FreezeBalls();
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
        gameplayCoinText.text = coinManager.noOfCoinsCollected.ToString();
        gameplayScoreText.text = scoreManager.score.ToString();
        gameplayCanvas.enabled = true;
        swipeController.enabled = true;
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
