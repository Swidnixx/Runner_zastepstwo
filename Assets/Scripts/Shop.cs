using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ImmortalitySO battery;
    public Text batteryLevelText;
    public Text batteryPriceText;

    int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");

        Refresh();
    }

    void Refresh()
    {
        batteryLevelText.text = $"Level {battery.level}";
        batteryPriceText.text = $"$ {battery.upgradePrice}";
    }

    public void UpgradeBattery()
    {
        if (coins >= battery.upgradePrice)
        {
            coins -= battery.upgradePrice;
            PlayerPrefs.SetInt("Coins", coins);

            battery = battery.nextLevelBattery;
            Refresh();
        }
    }
}
