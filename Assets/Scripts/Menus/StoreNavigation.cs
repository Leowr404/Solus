using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreNavigation : MonoBehaviour
{
    public Button buyButton;
    public Text buyText;
    public GameObject coinManager;

    public List<Text> texts = new List<Text>();
    public List<int> prices = new List<int>();

    [SerializeField] int currentItem = 0;
    [SerializeField] int currentPrice = 0;

    private CoinController coinController;


    //obtem a variavel "coin" do CoinController e da a primeira atualizada no display
    private void Start()
    {
        coinController = coinManager.GetComponent<CoinController>();
ChangePriceDisplay();
    }

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
        buyText.text = prices[currentPrice].ToString();

        if(coinController.coin < prices[currentPrice]) {
            buyButton.interactable = false;
        }
        else buyButton.interactable = true;

    }

    //por enquanto eh chamado quando o jogador aperta no botao com o preco e subtrai ele do saldo
    public void BuyItem()
    {
        coinController.coin = coinController.coin - prices[currentPrice];
        coinController.UpdateCoins();

        ChangePriceDisplay();

    }

}
