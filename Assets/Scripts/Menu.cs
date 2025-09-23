using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highscoreText;
    public Text coinsText;

    public GameObject panelMenu;
    public GameObject panelShop;

    int coins;

    private void Start()
    {
        BackToMenu();
    }
    void UpdateInfo()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
        highscoreText.text = "error";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToShop()
    {
        panelMenu.SetActive(false);
        panelShop.SetActive(true);
    }
    public void BackToMenu()
    {
        panelMenu.SetActive(true);
        panelShop.SetActive(false);
        UpdateInfo();
    }
}
