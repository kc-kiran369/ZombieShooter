using UnityEngine;

public class GameManager : MonoBehaviour
{
    internal static float currentGameTimeInSeconds;
    private void Update()
    {
        if (GameState.currentGameState == GameState.CurrentGameState.Playing)
        {
            CalculateTimeInSeconds();
        }
    }
    private void CalculateTimeInSeconds()
    {
        currentGameTimeInSeconds += 0.8f * Time.deltaTime;
    }
}
