using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameStateManager gameStateManager;
    public MainMenuScreen mainMenuScreen;
    public GameplayScreen gameplayScreen;
    public PauseScreen pauseScreen;
    public GameOverScreen gameOverScreen;



    private void OnEnable()
    {
        gameStateManager.main += OnChangeContent;
    }

    public void OnChangeContent()
    {
        switch(gameStateManager.currentGameState)
        {
            case GameState.MainMenu:
                Debug.Log("MainMenu");
                mainMenuScreen.ShowScreen();
                pauseScreen.HideScreens();
                gameplayScreen.HideScreens();
                gameOverScreen.HideScreens();
                break;

            case GameState.Gameplay:
                Debug.Log("Gameplay");
                gameplayScreen.ShowScreen();
                pauseScreen.HideScreens();
                mainMenuScreen.HideScreens();
                gameOverScreen.HideScreens();
                break;

            case GameState.Pause:
                Debug.Log("Pause");
                pauseScreen.ShowScreen();
                mainMenuScreen.HideScreens();
                gameplayScreen.HideScreens();
                gameOverScreen.HideScreens();
                break;
            
            case GameState.GameOver:
                Debug.Log("GameOverScreen");
                gameOverScreen.ShowScreen();
                mainMenuScreen.HideScreens();
                gameplayScreen.HideScreens();
                pauseScreen.HideScreens();
                break;
        }
        
    }

    private void OnDisable()
    {
        gameStateManager.main -= OnChangeContent;
    }
}