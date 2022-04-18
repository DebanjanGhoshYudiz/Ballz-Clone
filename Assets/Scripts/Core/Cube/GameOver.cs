using UnityEngine;

public class GameOver : MonoBehaviour
{ 
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("cube"))
        {
            Debug.Log("GameOver!");
            gameStateManager.currentGameState = GameState.GameOver;
            gameStateManager.main?.Invoke();
            coinManager.SetCoins();
            scoreManager.CheckHighscore();
        }
    }
}
