using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TMP_Text moneyText;

    public int targetMoney = 1000;

    public static int totalMoney = 0;
    public static int moneyCollected = 0;
    public static int targetMoneyStatic = 1000;

    void Start()
    {
        totalMoney = 0;
        moneyCollected = 0;
        targetMoneyStatic = targetMoney;
    }

    void Update()
    {
        moneyText.text = "$ " + totalMoney + " / " + targetMoneyStatic;
    }
}