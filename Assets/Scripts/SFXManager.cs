using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public GameObject sfxOnButton;
    public GameObject sfxOffButton;

    void Start()
    {
        int sfx = PlayerPrefs.GetInt("SFX", 1);

        if (sfxOnButton != null)
            sfxOnButton.SetActive(sfx == 1);

        if (sfxOffButton != null)
            sfxOffButton.SetActive(sfx == 0);
    }

    public void TurnSFXOff()
    {
        if (sfxOnButton != null)
            sfxOnButton.SetActive(false);

        if (sfxOffButton != null)
            sfxOffButton.SetActive(true);

        PlayerPrefs.SetInt("SFX", 0);
    }

    public void TurnSFXOn()
    {
        if (sfxOnButton != null)
            sfxOnButton.SetActive(true);

        if (sfxOffButton != null)
            sfxOffButton.SetActive(false);

        PlayerPrefs.SetInt("SFX", 1);
    }

    public static bool IsSFXOn()
    {
        return PlayerPrefs.GetInt("SFX", 1) == 1;
    }
}