using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    public List<ScreenView> screenList;
    public Canvas currentCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType(typeof(UIManager)) as UIManager;
        }
        else
        {
            instance = this;
        }
    }
    

    private void Start()
    {
        ShowScreen(Screens.MainMenuScreen);
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
        }
        currentCanvas = screenList.Find(x => x.screenEnum == screen).screen;
        currentCanvas.enabled = true;
    }

}
