using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    [SerializeField] private GameObject mainBall;
    [SerializeField] private BallManager ballManager;
    [SerializeField] private Spawner spawnerScript;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SwipeController swipeController;

    public void OnGameRestart()
    {
        mainBall.transform.position = ballManager.mainBallPosition;
        ballManager.RemoveBall();
        spawnerScript.GameResetSpawn();
        scoreManager.ScoreReset();
        swipeController.enabled = true;
    }
}
