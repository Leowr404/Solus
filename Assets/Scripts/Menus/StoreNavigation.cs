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
    public List<Text> pricesText;
    public List<int> itemsPrice;
    //   public List<Text> itemsText;

    public string textoEquipado = "EQUIPADO";
    public string textoEquipar = "Equipar";

    public GameObject coinManager;
    public GameObject inventoryControl;

    private CoinController coinController;
    private InventoryController inventoryController;


    //obtem a variavel "coin" do CoinController e da a primeira atualizada no display
    private void Start()
    {
        coinController = coinManager.GetComponent<CoinController>();
        inventoryController = inventoryControl.GetComponent<InventoryController>();

        SetPricesText();
        StartingPriceDisplay();

     
    }

    void SetPricesText()
    {
        for(int i=0; i<pricesText.Count; i++)
        {
            pricesText[i].text = itemsPrice[i + 1].ToString();

        }

    }

    public void BuyItem(int buttonIndex)
    {
        coinController.coin = coinController.coin - itemsPrice[buttonIndex];
        coinController.UpdateCoins();

        //torna o bool de item obtido no script de inventario verdadeiro
    

        itemsButtons[buttonIndex].gameObject.SetActive(false);
        equipButtons[buttonIndex].gameObject.SetActive(true);

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

    public void EquipItem(int buttonIndex)
    {

        itemsText[buttonIndex].text = textoEquipado;

        inventoryController.equipped[buttonIndex] = true;
        UnequipItem(buttonIndex);
    }

    void UnequipItem(int buttonIndex)
    {
        for(int i = 0; i <equipButtons.Count; i++)
        {
            if (itemsText[i].text == textoEquipado && i != buttonIndex)
            {
                itemsText[i].text = textoEquipar;
                inventoryController.equipped[i] = false;

            }


        }

    }

   





   








  

}
