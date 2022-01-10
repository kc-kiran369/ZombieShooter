using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TMP_Text currentTimeText;
    int currentTimeInMinute = 0;
    byte currentTimeInHour = 10;
    byte currentNum, previousNum = 0;
    private void Update()
    {
        UpdateTimeCanvas();
    }
    private void UpdateTimeCanvas()
    {
        currentTimeInMinute = (int)(GameManager.currentGameTimeInSeconds) % 60;
        currentNum = (byte)currentTimeInMinute;
        if (GameState.currentGameState == GameState.CurrentGameState.Playing && currentNum != previousNum)
        {
            if (currentTimeInMinute == 59)
            {
                currentTimeInHour %= 12;
                currentTimeInHour++;
                if (currentNum == 0)
                {
                    currentNum = 1;
                }
            }
            currentTimeText.text = currentTimeInHour + ":" + currentTimeInMinute;
        }
        previousNum = currentNum;
    }
}
