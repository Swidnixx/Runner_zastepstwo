using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ImmortalitySO battery;
    public Text batteryLevelText;
    public Text batteryPriceText;

    public MagnetSO magnet;
    public Text magnetLevelText;
    public Text magnetPriceText;

    int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");

        if (PlayerPrefs.HasKey("Battery")) 
            battery = Resources.Load<ImmortalitySO>(PlayerPrefs.GetString("Battery"));

        if (PlayerPrefs.HasKey("Magnet"))
            magnet = Resources.Load<MagnetSO>(PlayerPrefs.GetString("Magnet"));

        Refresh();
    }

    void Refresh()
    {
        batteryLevelText.text = $"Level {battery.level}";
        batteryPriceText.text = $"$ {battery.upgradePrice}";
        if (battery.nextLevelBattery == null)
        {
            batteryPriceText.text = "Max level";
        }

        magnetLevelText.text = $"Level {magnet.level}";
        magnetPriceText.text = $"$ {magnet.upgradePrice}";
        if (magnet.nextLevelMagnet == null)
        {
            magnetPriceText.text = "Max level";
        }
    }

    public void UpgradeBattery()
    {
        if (battery.nextLevelBattery == null) return;

        if (coins >= battery.upgradePrice)
        {
            coins -= battery.upgradePrice;
            PlayerPrefs.SetInt("Coins", coins);

            battery = battery.nextLevelBattery;
            Refresh();

            PlayerPrefs.SetString("Battery", battery.name);
        }
    }

    public void UpgradeMagnet()
    {
        if (magnet.nextLevelMagnet == null) return;

        if (coins >= magnet.upgradePrice)
        {
            coins -= magnet.upgradePrice;
            PlayerPrefs.SetInt("Coins", coins);

            magnet = magnet.nextLevelMagnet;
            Refresh();

            PlayerPrefs.SetString("Magnet", magnet.name);
        }
    }
}
