using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public Text amountOfCoins;

    private static CoinController instance;

    public int coin = 0;

    private void Awake()
    {
        // Garante que apenas uma instância do SceneController exista na cena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void Start()
    {

        if (amountOfCoins != null)
        {
            amountOfCoins.text = coin.ToString();
        }
    }

    public void UpdateCoins()
    {
        amountOfCoins.text = coin.ToString();
    }
}