using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    public GameStateManager gameStateManager;
    public CoinManager coinManager;
    public Canvas mainMenuCanvas;

    private void Start()
    {
        coinManager.GetCoins();
    }

    public void ShowScreen()
    {
        mainMenuCanvas.enabled = true;
    }

    public void OnClickPlay()
    {
        gameStateManager.currentGameState = GameState.Gameplay;
        gameStateManager.main?.Invoke();
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void HideScreens()
    {
        mainMenuCanvas.enabled = false;
    }
    
}
