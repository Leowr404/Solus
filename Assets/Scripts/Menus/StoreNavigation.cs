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

        SetBoughtItems();
        SetPricesText();
        StartingPriceDisplay();

     
    }

    public void ResetStore()
    {
for(int i = 1; i < itemsButtons.Count; i++)
        {
            itemsButtons[i].gameObject.SetActive(true);
            equipButtons[i].gameObject.SetActive(false);

        }

        itemsText[0].text = textoEquipado;

        StartingPriceDisplay();

    }

    public void SetBoughtItems()
    {

        for(int i = 0; i < itemsText.Count; i++)
        {
            if (inventoryController.bought[i])
            {

                itemsButtons[i].gameObject.SetActive(false);
                equipButtons[i].gameObject.SetActive(true);

                itemsText[i].text = textoEquipar;

            }

        }

        for(int i = 0; i < itemsText.Count;i++)
        {
            if (inventoryController.equipped[i]) {

                itemsText[i].text = textoEquipado;
            
            }

        }


    }

    public void SetPricesText()
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
        inventoryController.bought[buttonIndex] = true;
        inventoryController.CallSaveBought();

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

            else itemsButtons[i].interactable = true;

        }

    }

    public void EquipItem(int buttonIndex)
    {

           itemsText[buttonIndex].text = textoEquipado;

        inventoryController.equipped[buttonIndex] = true;
        UnequipItem(buttonIndex);
        inventoryController.CallSaveEquip();
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
