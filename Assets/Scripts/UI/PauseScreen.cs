using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private GameplayScreen gameplayScreen;
    [SerializeField] private MainBallMovement mainBallMovement;
    [SerializeField] private SwipeController swipeController;
    
    [Header("UI")]
    [SerializeField] private Canvas pausedCanvas;

    [Header("Audio")]
    public bool sfxIsPlaying = true;
    public Image sfxBtn;
    public Sprite sfxOn;
    public Sprite sfxOff;
    

    public void ShowScreen()
    {
        pausedCanvas.enabled = true;
    }

    public void OnClickContinue()
    {
        gameStateManager.currentGameState = GameState.Gameplay;
        gameStateManager.main?.Invoke();
        mainBallMovement.mainBallRd2D.constraints = RigidbodyConstraints2D.None;
        mainBallMovement.mainBallRd2D.velocity = gameplayScreen.storeVelocity;
        swipeController.enabled = true;
    }

    public void OnClickMainMenu()
    {
        gameStateManager.currentGameState = GameState.MainMenu;
        SceneManager.LoadScene(0);
    }
    
    

    public void OnClickSfxSound()
    {
        if (!sfxIsPlaying)
        {
            AudioManager.instance.PlaySfx();
            sfxBtn.sprite = sfxOn;
            sfxIsPlaying = true;
        }
        else if (sfxIsPlaying)
        {
            AudioManager.instance.StopSfx();
            sfxBtn.sprite = sfxOff;
            sfxIsPlaying = false;
        }
    }

    public void HideScreens()
    {
        pausedCanvas.enabled = false;
    }
}
