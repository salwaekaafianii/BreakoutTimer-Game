using UnityEngine;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    public Transform door;
    public GameObject WinPanel; // UI Panel
    public TextMeshProUGUI moneyText;

    private bool opened = false;

    private void Start()
    {
        WinPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            opened = true;

            // buka pintu
            door.Rotate(0f, -90f, 0f);

            // tampilkan panel
            WinPanel.SetActive(true);
            moneyText.text = "Total Uang: $" + MoneyManager.totalMoney;

            // pause game
            Time.timeScale = 0f;

            Debug.Log("Pencuri berhasil kabur!");
            Debug.Log("Total uang yang dicuri: $" + MoneyManager.totalMoney);
        }
    }
}