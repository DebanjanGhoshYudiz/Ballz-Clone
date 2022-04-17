using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    public GameStateManager gameStateManager;
    public CoinManager coinManager;
    public Canvas gameplayCanvas;
    public Text gameplayCoinText;
    

    private void Start()
    {
        gameplayCoinText.text = coinManager.noOfCoinsCollected.ToString();
    }

    public void OnClickPause()
    {
        gameStateManager.currentGameState = GameState.Pause;
        gameStateManager.main?.Invoke();
    }

    public void ShowScreen()
    {
        gameplayCanvas.enabled = true;
    }

    public void HideScreens()
    {
        gameplayCanvas.enabled = false;
    }

    
}
