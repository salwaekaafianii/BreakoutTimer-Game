using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TMP_Text moneyText;

    public static int totalMoney = 0;

    void Update()
    {
        moneyText.text = "$ " + totalMoney;
    }
}