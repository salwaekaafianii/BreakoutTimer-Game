using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadSceneBaru(string sceneName)
    {
        Time.timeScale = 1f;

        // Reset uang saat masuk level
        if (sceneName == "Level 1" || sceneName == "Level 2")
        {
            MoneyManager.totalMoney = 0;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel2()
    {
        Time.timeScale = 1f;

        // Reset uang
        MoneyManager.totalMoney = 0;

        SceneManager.LoadScene("Level 2");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}