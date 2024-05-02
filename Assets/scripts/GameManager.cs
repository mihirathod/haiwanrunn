using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] playerPrefabe;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;
    private const string coinCountKey = "CoinCount";
    public GameObject endgameui;
    // Start is called before the first frame update
    private void Start()
    {
        LoadCoinCount();
        UpdateCoinText();
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Instantiate(playerPrefabe[PlayerPrefs.GetInt("CurrentPlayer")], transform);
    }
    public void IncrementCoinCount()
    {
        coinCount++;
        UpdateCoinText();
        SaveCoinCount();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
    private void SaveCoinCount()
    {
        PlayerPrefs.SetInt(coinCountKey, coinCount);
        PlayerPrefs.Save();
    }

    private void LoadCoinCount()
    {
        if (PlayerPrefs.HasKey(coinCountKey))
        {
            coinCount = PlayerPrefs.GetInt(coinCountKey);
        }
    }



    public void playgame()
    {
        SceneManager.LoadScene("scene1");
        Time.timeScale = 1f;

    }

    public void pausegame()
    {
        Time.timeScale = 0f;
    }

    public void resmegame()
    {
        Time.timeScale = 1f;

    }

    public void endgame()
    {
        endgameui.SetActive(true);
        Time.timeScale = 0f;
    }
}
