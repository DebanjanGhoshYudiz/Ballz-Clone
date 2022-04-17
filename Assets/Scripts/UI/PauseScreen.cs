using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    //public GameStateManager gameStateManager;
    public Canvas pausedCanvas;
    

    public void ShowScreen()
    {
        pausedCanvas.enabled = true;
    }

    public void HideScreens()
    {
        pausedCanvas.enabled = false;
    }
}
