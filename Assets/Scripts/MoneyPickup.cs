using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    public int moneyValue = 1000;
    public AudioClip moneySound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoneyManager.totalMoney += moneyValue;

            if (SFXManager.IsSFXOn())
            {
                AudioSource.PlayClipAtPoint(
     moneySound,
     transform.position,
     0.9f
 );
            }

            Debug.Log("Mengambil uang $" + moneyValue);

            Destroy(gameObject);
        }
    }
}