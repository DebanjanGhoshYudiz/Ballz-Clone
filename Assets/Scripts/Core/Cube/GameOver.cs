using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("cube") || col.gameObject.CompareTag("Coin") || col.gameObject.CompareTag("ExtraBall"))
        {
            Debug.Log("GameOver!");
            UIManager.instance.ShowScreen(Screens.GameOverScreen);
            GameEvents.GameOverContent();
        }
    }
}
