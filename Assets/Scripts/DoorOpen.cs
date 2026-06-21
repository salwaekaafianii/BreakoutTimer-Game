using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Transform door;

    private bool opened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            opened = true;

            // Membuka pintu
            door.Rotate(0f, -90f, 0f);
        }
    }
}