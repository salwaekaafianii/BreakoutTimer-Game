using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    public Button level2Button;
    public GameObject lockImage;

    void Start()
    {
        int value = PlayerPrefs.GetInt("Level2Unlocked", 0);

        Debug.Log("Level2Unlocked = " + value);

        bool unlocked = value == 1;

        level2Button.interactable = unlocked;
        lockImage.SetActive(!unlocked);
    }
}