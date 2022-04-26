using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private BallManager ballManager;
    [SerializeField] private Spawner spawnerScript;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SwipeController swipeController;
    [SerializeField] private GameObject mainBall;
    [SerializeField] private CoinManager coinManager;
    
    [Header("Action")]
    public Action GameOverReset;
    public Action OnResume;
    public Action OnGameOver;

    private void OnEnable()
    {
        GameOverReset += GameOverResetContent;
        OnResume += PauseOnResume;
        OnGameOver += GameOverContent;
    }

    public void GameOverResetContent()
    {
        mainBall.transform.position = ballManager.mainBallPosition;
        ballManager.RemoveBall();
        spawnerScript.GameResetSpawn();
        scoreManager.ScoreReset();
        swipeController.enabled = true;
    }

    public void PauseOnResume()
    {
        ballManager.UnFreezeBalls();
        ballManager.GiveVelocity();
        swipeController.enabled = true;
    }

    public void GameOverContent()
    {
        swipeController.enabled = false;
        coinManager.SetCoins();
        scoreManager.CheckHighscore();
        ballManager.FreezeBalls();
    }

    private void OnDisable()
    {
        GameOverReset -= GameOverResetContent;
        OnResume -= PauseOnResume;
        OnGameOver -= GameOverContent;
    }
}
