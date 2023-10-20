using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreNavigation : MonoBehaviour
{

    public List<Button> itemsButtons;
    public List<Button> equipButtons;
    public List<Text> itemsText;
    public List<int> itemsPrice;
    //   public List<Text> itemsText;

    public GameObject coinManager;
    public GameObject inventoryControl;

    private CoinController coinController;
    private InventoryController inventoryController;


    //obtem a variavel "coin" do CoinController e da a primeira atualizada no display
    private void Start()
    {
        coinController = coinManager.GetComponent<CoinController>();
        inventoryController = inventoryControl.GetComponent<InventoryController>();

        StartingPriceDisplay();

        ChangePriceDisplay();
    }


    public void BuyItem(int buttonIndex)
    {
        coinController.coin = coinController.coin - prices[currentPrice];
        coinController.UpdateCoins();

        //torna o bool de item obtido no script de inventario verdadeiro
        inventoryController.bought[buttonIndex] = true;

        itemsButtons[buttonIndex].gameObject.SetActive(false);
        equipButtons[buttonIndex].gameObject.SetActive(true);

    }

    public void EquipItem(int buttonIndex)
    {
        Debug.Log(buttonIndex);
        itemsText[buttonIndex].text = "EQUIPADO";

    }

    public void StartingPriceDisplay()
    {
        for(int i = 0; i < itemsPrice.Count; i++)
        {
            if (coinController.coin < itemsPrice[i])
            {
                itemsButtons[i].interactable = false;

            }

        }

    }



    /*void ChangePriceDisplay()
    {
        if (inventoryController.bought[currentItem])
        {
            buyText.text = "sold out";
            buyButton.interactable = false;
        }

        else { 
        buyText.text = prices[currentPrice].ToString();

        if(coinController.coin < prices[currentPrice]) {
            buyButton.interactable = false;
        }
        else buyButton.interactable = true;
        }
    }*/










    public Button buyButton;
    public Text buyText;



    public List<Text> texts = new List<Text>();
    public List<int> prices = new List<int>();

    [SerializeField] int currentItem = 0;
    [SerializeField] int currentPrice = 0;

  



    //chamado quando aperta a seta apontada pra direita, passa pro proximo item da lista, caso seja o ultimo, retorna ao primeiro
    public void NextStoreItem()
    {
        texts[currentItem].gameObject.SetActive(false);

        if (currentItem == texts.Count - 1)
        {
            currentItem = 0;
            currentPrice = 0;
            ChangePriceDisplay();
        }
        else
        {
            currentItem++;
            currentPrice++;
            ChangePriceDisplay();
        }
            texts[currentItem].gameObject.SetActive(true);
            
    }
    //chamado quando aperta a seta apontada pra esquerda, passa pro item anterior da lista, caso seja o primeiro, retorna ao ultimo
    public void PreviousStoreItem()
    {
        texts[currentItem].gameObject.SetActive(false);

        if (currentItem == 0)
        {
            currentItem = texts.Count - 1;
            currentPrice = prices.Count - 1;
            ChangePriceDisplay();
        }
        else
        {
            currentItem--;
            currentPrice--;
            ChangePriceDisplay();
        }
        texts[currentItem].gameObject.SetActive(true);

    }
    //atualiza o texto para ficar igual ao preco do item em questao, caso o jogador tenha menos moedas que o preco, torna o botao impossivel de se interagir
    void ChangePriceDisplay()
    {
        if (inventoryController.bought[currentItem])
        {
            buyText.text = "sold out";
            buyButton.interactable = false;
        }

        else { 
        buyText.text = prices[currentPrice].ToString();

        if(coinController.coin < prices[currentPrice]) {
            buyButton.interactable = false;
        }
        else buyButton.interactable = true;
        }
    }

    //por enquanto eh chamado quando o jogador aperta no botao com o preco e subtrai ele do saldo
   /* public void BuyItem()
    {
        coinController.coin = coinController.coin - prices[currentPrice];
        coinController.UpdateCoins();
        inventoryController.bought[currentItem] = true;

        ChangePriceDisplay();

    }*/

}
