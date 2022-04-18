using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text scoreText;
    [SerializeField] private ScoreManager scoreManager;
    

    public void ShowScreen()
    {
        gameOverCanvas.enabled = true;
        highScoreText.text = scoreManager.highScore.ToString();
        scoreText.text = scoreManager.score.ToString();
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

    public void HideScreens()
    {
        gameOverCanvas.enabled = false;
    }
}
