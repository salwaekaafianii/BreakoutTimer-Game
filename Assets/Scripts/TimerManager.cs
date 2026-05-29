using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 300f;

    public TMP_Text timerText;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timeRemaining = 0;

            timerText.text = "00:00";

            Debug.Log("GAME OVER");

            gameEnded = true;

            Time.timeScale = 0f;
        }
    }
}