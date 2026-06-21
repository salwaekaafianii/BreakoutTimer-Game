using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 300f;
    public TMP_Text timerText;
    public GameObject gameOverPanel;

    private bool gameEnded = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        timeRemaining = 0;
        timerText.text = "00:00";
        
        MoneyManager.totalMoney = 0;

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        gameEnded = true;
    
    }
}