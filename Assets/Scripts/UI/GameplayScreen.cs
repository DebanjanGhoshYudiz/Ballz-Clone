using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
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
        gameplayScoreText.text = scoreManager.score.ToString();
    }


    public void OnClickPause()
    {
        UIManager.instance.ShowScreen(Screens.PauseScreen);
        GameEvents.GameplayPause();
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

    // public void ShowScreen()
    // {
    //     gameplayCoinText.text = coinManager.noOfCoinsCollected.ToString();
    //     gameplayScoreText.text = scoreManager.score.ToString();
    //     swipeController.enabled = true;
    // }

    private void OnDisable()
    {
        coinManager.updateCoin -= UpdateCoin;
    }
}
