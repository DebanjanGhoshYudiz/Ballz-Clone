public static class GameEvents 
{
    public delegate void GameOverReset();
    public delegate void OnResume();
    public delegate void OnGameOver();
    public delegate void OnGameplayPause();
    public delegate void OnPlay();
    public static event GameOverReset ResetGame;
    public static event OnResume onResume;
    public static event OnGameOver onGameOver;
    public static event OnGameplayPause onGameplayPause;
    public static event OnPlay onPlay;
    
    public static void GameOverResetContent()
    {
        ResetGame?.Invoke();
    }

    public static void PauseOnResume()
    {
        onResume?.Invoke();
    }

    public static void GameOverContent()
    {
        onGameOver?.Invoke();
    }

    public static void GameplayPause()
    {
        onGameplayPause?.Invoke();
    }
    
    public static void PlayGame()
    {
        onPlay?.Invoke();
    }
}
    
