using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager;
    public List<ScreenView> screenList;
    public Canvas currentCanvas;


    private void OnEnable()
    {
        gameStateManager.main += ShowScreen;
    }

    private void OnDisable()
    {
        gameStateManager.main -= ShowScreen;
    }

    [System.Serializable]
    public class ScreenView
    {
        public Canvas screen;
        public Screens screenEnum;
    }
    
    public void ShowScreen(Screens screen)
    {
        if (currentCanvas != null)
        {
            currentCanvas.enabled = false;
            currentCanvas = screenList.Find(x => x.screenEnum == screen).screen;
            currentCanvas.enabled = true;
        }
    }

}
