using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    //public GameStateManager gameStateManager;
    public Canvas gameOverCanvas;
    

    public void ShowScreen()
    {
        gameOverCanvas.enabled = true;
    }

    public void HideScreens()
    {
        gameOverCanvas.enabled = false;
    }
}
