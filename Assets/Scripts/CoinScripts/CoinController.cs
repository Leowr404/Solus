using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CoinController : MonoBehaviour
{
    [SerializeField]
    private Text amountOfCoins;
    public Text amountOfCoinsloja;



    public static CoinController instance;
    private bool isInGame = false;
    public int coin = 0;
    
    private void Awake()
    {
        LoadCoins();
        CheckGameState();
        if (!isInGame)
        {
            if(amountOfCoins != null) { 
            amountOfCoins.text = coin.ToString("D4");
            }
            if (amountOfCoinsloja != null) { 
            amountOfCoinsloja.text = coin.ToString("D4");
        }
        }
    }

   /* private void FixedUpdate()
    {
        if(Input.GetKeyUp(KeyCode.M)) {

            coin = coin + 4000;
            Debug.Log(coin);
        }
    }*/
    public void CollectCoin()
    {
        coin++;
        UpdateCoins(); 
    }

    public void UpdateCoins()
    {
       SaveCoins();
        if (!isInGame)
        {
            amountOfCoins.text = coin.ToString("D4");
            amountOfCoinsloja.text = coin.ToString("D4");
        }
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("PlayerCoins", coin);
        PlayerPrefs.Save();
    
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
    private void CheckGameState()
    {
        // Verifique se a cena atual é a cena do jogo
        isInGame = SceneManager.GetActiveScene().name == "Jogo";
    }

    public void ResetCoin()
    {
        PlayerPrefs.SetInt("PlayerCoins",0);
        PlayerPrefs.Save();
        LoadCoins();

        if (!isInGame)
        {
            amountOfCoins.text = coin.ToString("D4");
            amountOfCoinsloja.text = coin.ToString("D4");
        }
    }
}