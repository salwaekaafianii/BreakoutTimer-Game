using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    public int moneyValue = 1000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoneyManager.totalMoney += moneyValue;

            Debug.Log("Mengambil uang $" + moneyValue);

            Destroy(gameObject);
        }
    }
}