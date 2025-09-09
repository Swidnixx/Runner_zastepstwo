using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject gameOverPanel;
    public Text scoreText;
    public Text coinText;
    public float worldSpeed = 2.5f;
    float score;
    int coins;

    public ImmortalitySO Immortality;
    public MagnetSO Magnet;

    private void Start()
    {
        Immortality.IsActive = false;
        Magnet.IsActive = false;
    }

    private void Update()
    {
        score += worldSpeed * Time.deltaTime;
        scoreText.text = score.ToString("F0");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        Time.timeScale = 1;
    }

    public void CoinCollect()
    {
        coins++;
        coinText.text = coins.ToString();
    }

    public void ImmortalityCollected()
    {
        if (Immortality.IsActive)
            CancelInvoke(nameof(CancelImmortality));
        else
            worldSpeed += Immortality.SpeedBoost;
        Immortality.IsActive = true;
        Invoke(nameof(CancelImmortality), Immortality.Duration);
    }

    private void CancelImmortality()
    {
        Immortality.IsActive = false;
        worldSpeed -= Immortality.SpeedBoost;
    }

    public void MagnetCollected()
    {
        if (Magnet.IsActive)
            CancelInvoke(nameof(CancelMagnet));

        Magnet.IsActive = true;
        Invoke(nameof(CancelMagnet), Magnet.Duration);
    }

    private void CancelMagnet()
    {
        Magnet.IsActive = false;
    }
}
