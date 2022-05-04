using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;


    public void OnClickRestart()
    {
        UIManager.instance.ShowScreen(Screens.GameplayScreen);
        GameEvents.GameOverResetContent();
        scoreManager.ScoreReset();
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickExit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
    
}
