using System;
using UnityEngine;


public class GameEvents : MonoBehaviour
{
    public Action GameOverReset;
    public Action OnResume;
    public Action OnGameOver;
    public Action OnGameplayPause;



    public void GameOverResetContent()
    {
        GameOverReset?.Invoke();
    }

    public void PauseOnResume()
    {
        OnResume?.Invoke();
    }

    public void GameOverContent()
    {
        OnGameOver?.Invoke();
    }

    public void GameplayPause()
    {
        OnGameplayPause?.Invoke();
    }
}
    
