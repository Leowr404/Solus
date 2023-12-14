using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTextGameOver : MonoBehaviour
{
    public Text Coin;
    public Text thisText;

    void Awake()
    {
        thisText = GetComponent<Text>();
        UpdateText();
    }

    void UpdateText()
    {
        if (Coin != null && thisText != null)
        {
            thisText.text = Coin.text;
        }
    }
}
