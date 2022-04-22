using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private GameObject mainBall;
    [SerializeField] private MainBallMovement mainBallMovementScript;
    [SerializeField] private BallManager ballManager;
    [SerializeField] private Spawner spawnerScript;
    [SerializeField] private SwipeController swipeController;
    

    public void ShowScreen()
    {
        gameOverCanvas.enabled = true;
        highScoreText.text = scoreManager.highScore.ToString();
        scoreText.text = scoreManager.score.ToString();
    }

    public void OnClickRestart()
    {
        gameStateManager.currentGameState = GameState.Gameplay;
        gameStateManager.main?.Invoke();
        mainBall.transform.position = mainBallMovementScript.mainBallPosition;
        ballManager.RemoveBall();
        spawnerScript.GameResetSpawn();
        scoreManager.ScoreReset();
        swipeController.enabled = true;
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
