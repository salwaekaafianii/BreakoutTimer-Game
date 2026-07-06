using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

    // Dipanggil oleh semua tombol
    public void PlaySound()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            audioSource.Play();
        }
    }

    // Tombol Sound ON
    public void SoundOn()
    {
        PlayerPrefs.SetInt("SFX", 1);
        PlayerPrefs.Save();
    }

    // Tombol Sound OFF
    public void SoundOff()
    {
        PlayerPrefs.SetInt("SFX", 0);
        PlayerPrefs.Save();
    }
}