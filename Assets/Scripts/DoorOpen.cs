using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform door;
    public AudioSource doorSound;

    private bool opened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            opened = true;

            // Cek apakah SFX aktif
            if (PlayerPrefs.GetInt("SFX", 1) == 1)
            {
                if (doorSound != null)
                    doorSound.Play();
            }

            door.Rotate(0f, -90f, 0f);
        }
    }
}