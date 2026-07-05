using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource sound;

    void OnEnable()
    {
        if (SFXManager.IsSFXOn() && sound != null)
        {
            sound.Play();
        }
    }
}