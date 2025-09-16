using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highscoreText;
    public Text coinsText;

    int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");

        UpdateInfo();
    }
    void UpdateInfo()
    {
        coinsText.text = coins.ToString();
        highscoreText.text = "error";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
