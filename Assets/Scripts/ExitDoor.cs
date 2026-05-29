using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public Transform door;

    private bool opened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            opened = true;

            door.Rotate(0, 90, 0);

            Debug.Log("Pencuri berhasil kabur!");
            Debug.Log("Total uang yang dicuri: $" + MoneyPickup.totalMoney);
        }
    }
}