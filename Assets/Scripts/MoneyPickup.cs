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
            MoneyManager.moneyCollected++;

            Debug.Log("Total Money = " + MoneyManager.totalMoney);

            if (SFXManager.IsSFXOn())
            {
                AudioSource.PlayClipAtPoint(
                    moneySound,
                    transform.position,
                    0.9f
                );
            }

            Destroy(gameObject);
        }
    }
}