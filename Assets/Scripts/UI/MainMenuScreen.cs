using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    
    [Header("Script Reference")]
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private ScoreManager scoreManager;
    
    [Header("UI")]
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Text gameplayScoreText;
    
    [Header("Audio")]
    [SerializeField] private Image sfxBtn;
    [SerializeField] private Sprite sfxOn;
    [SerializeField] private Sprite sfxOff;
    private bool _sfxIsPlaying = true;
    
    
    private void Start()
    {
        coinManager.GetCoins();
        scoreManager.GetHighscore();
    }
    
    public void OnClickPlay()
    {
        gameStateManager.currentGameState = GameState.Gameplay;
        gameStateManager.main?.Invoke(Screens.GameplayScreen);
        scoreManager.ScoreReset();
        gameplayScoreText.text = scoreManager.score.ToString();
        GameEvents.PlayGame();
    }

    public void OnClickSfxSound()
    {
        if (!_sfxIsPlaying)
        {
            AudioManager.instance.PlaySfx();
            sfxBtn.sprite = sfxOn;
            _sfxIsPlaying = true;
        }
        else if (_sfxIsPlaying)
        {
            AudioManager.instance.StopSfx();
            sfxBtn.sprite = sfxOff;
            _sfxIsPlaying = false;
        }
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    
}
