using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private GameEvents gameEvents;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("cube") || col.gameObject.CompareTag("Coin") || col.gameObject.CompareTag("ExtraBall"))
        {
            Debug.Log("GameOver!");
            gameStateManager.currentGameState = GameState.GameOver;
            gameStateManager.main?.Invoke();
            gameEvents.OnGameOver?.Invoke();
        }
    }
}
