using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CoinController : MonoBehaviour
{
    [SerializeField]
    private Text amountOfCoins;

    public static CoinController instance;

    public int coin = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
         DontDestroyOnLoad(transform.root.gameObject);
        

    }

    private void Start()
    {
        LoadCoins();
        
        amountOfCoins.text = coin.ToString("D4");
    }
    public void CollectCoin()
    {
        coin++;
        UpdateCoins(); 
    }

    public void UpdateCoins()
    {
       SaveCoins();
       FindCoinText();
        if (amountOfCoins != null)
        {
            amountOfCoins.text = coin.ToString("D4");
        }
        else
        {
            Debug.LogError("Texto de moedas não encontrado dinamicamente.");
        }
       amountOfCoins.text = coin.ToString("D4");
    }
    private void OnEnable()
    {
        if (amountOfCoins != null)
        {
            amountOfCoins.text = coin.ToString("D4");
        }
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("PlayerCoins", coin);
        PlayerPrefs.Save();
        Debug.Log("Moedas salvas: " + coin);
    }

    
    private void LoadCoins()
    {
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            coin = PlayerPrefs.GetInt("PlayerCoins");
            Debug.Log("Moedas carregadas: " + coin);
        }
        else
        {
            Debug.Log("Nenhuma moeda salva encontrada.");
        }
    }

    private void FindCoinText()
    {
        // Tente encontrar a referência do Text no objeto atual ou na cena
        amountOfCoins = GetComponentInChildren<Text>();
        if (amountOfCoins == null)
        {
            amountOfCoins = FindObjectOfType<Text>();
        }
    }
}