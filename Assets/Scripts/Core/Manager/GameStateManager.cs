using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameState currentGameState = GameState.MainMenu;
    public Action main;
}
