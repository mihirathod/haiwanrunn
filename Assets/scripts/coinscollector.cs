using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinscollector : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int Coinamount;
    void Start()
    {
        text = FindObjectOfType<TextMeshProUGUI>();
        text.text = PlayerPrefs.GetInt("Coinamount").ToString();
        Coinamount = PlayerPrefs.GetInt("Coinamount");
    }
    private void Update()
    {
        text.text = "Coins:" + Coinamount.ToString();

        PlayerPrefs.SetInt("Coinamount", Coinamount);

    }
}
