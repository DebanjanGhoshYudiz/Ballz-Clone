public delegate void GameOverReset();
public delegate void OnResume();

public delegate void OnGameOver();

public delegate void OnGameplayPause();
public static class GameEvents 
{
    public static event GameOverReset gameOverReset;
    public static event OnResume onResume;
    public static event OnGameOver onGameOver;
    public static event OnGameplayPause onGameplayPause;
    
    public static void GameOverResetContent()
    {
        gameOverReset?.Invoke();
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
}
    
