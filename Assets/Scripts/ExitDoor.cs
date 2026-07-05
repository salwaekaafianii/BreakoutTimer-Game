using UnityEngine;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    public Transform door;
    public GameObject WinPanel;
    public TextMeshProUGUI moneyText;
    public AudioSource winSound;

    private bool opened = false;

    private void Start()
    {
        WinPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Total = " + MoneyManager.totalMoney);
        Debug.Log("Target = " + MoneyManager.targetMoneyStatic);

        if (MoneyManager.totalMoney < MoneyManager.targetMoneyStatic)
        {
            Debug.Log("Ambil semua uang dulu!");
            return;
        }

        if (opened)
            return;

        opened = true;

        // Buka pintu
        door.Rotate(0f, -90f, 0f);

        if (PlayerPrefs.GetInt("SFX", 1) == 1 && winSound != null)
            winSound.Play();

        WinPanel.SetActive(true);
        moneyText.text = "Total Uang: $" + MoneyManager.totalMoney;

        PlayerPrefs.SetInt("Level2Unlocked", 1);
        PlayerPrefs.Save();

        Debug.Log("Saved = " + PlayerPrefs.GetInt("Level2Unlocked"));

        Time.timeScale = 0f;
    }
}