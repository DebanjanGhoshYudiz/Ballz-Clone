using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private MainBallMovement mainBall;
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
        storeVelocity = mainBall.mainBallRd2D.velocity;
        mainBall.mainBallRd2D.constraints = RigidbodyConstraints2D.FreezeAll;
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
