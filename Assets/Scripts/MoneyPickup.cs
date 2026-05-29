using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    public int moneyValue = 1000;

    public static int totalMoney = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            totalMoney += moneyValue;

            Debug.Log("Mengambil uang $" + moneyValue);
            Debug.Log("Total uang sekarang: $" + totalMoney);

            Destroy(gameObject);
        }
    }
}