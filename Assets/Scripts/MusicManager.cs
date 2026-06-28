using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource bgm;
    public GameObject musicOnButton;
    public GameObject musicOffButton;

    void Start()
    {
        int music = PlayerPrefs.GetInt("Music", 1);

        bgm.mute = (music == 0);

        if (musicOnButton != null)
            musicOnButton.SetActive(music == 1);

        if (musicOffButton != null)
            musicOffButton.SetActive(music == 0);
    }
    public void TurnMusicOff()
    {
        bgm.mute = true;

        if (musicOnButton != null)
            musicOnButton.SetActive(false);

        if (musicOffButton != null)
            musicOffButton.SetActive(true);

        PlayerPrefs.SetInt("Music", 0);
    }

    public void TurnMusicOn()
    {
        bgm.mute = false;

        if (musicOnButton != null)
            musicOnButton.SetActive(true);

        if (musicOffButton != null)
            musicOffButton.SetActive(false);

        PlayerPrefs.SetInt("Music", 1);
    }
}