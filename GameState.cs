using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public enum CurrentGameState
    {
        pauseMenu,
        Playing
    }
    public static CurrentGameState currentGameState = CurrentGameState.Playing;

}
