using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private static InventoryController instance;
    public GameObject storeNavigation;
    public List<bool> equipped;
    public List<bool> bought;


    private StoreNavigation store;

    void Awake()
    {
        if (storeNavigation != null)
        {
            store = storeNavigation.GetComponent<StoreNavigation>();
        }

        // Carrega as listas de booleanos dos PlayerPrefs ao iniciar


        LoadItems();
    }

    public void CallSaveEquip()
    {
        SaveItems();
    }

    public void CallSaveBought()
    {
        SaveBought();
    }

    private void SaveItems()
    {
        // Salva a lista equipped
        string equippedAsString = ConvertBoolListToString(equipped);
        PlayerPrefs.SetString("EquippedItems", equippedAsString);

        PlayerPrefs.Save();
    }

    private void SaveBought()
    {
        // Salva a lista bought
        string boughtAsString = ConvertBoolListToString(bought);
        PlayerPrefs.SetString("BoughtItems", boughtAsString);

        PlayerPrefs.Save();

    }

    private void LoadItems()
    {
        // Carrega a string do PlayerPrefs para a lista equipped
        string equippedAsString = PlayerPrefs.GetString("EquippedItems", "");
        equipped = ConvertStringToBoolList(equippedAsString);

        // Carrega a string do PlayerPrefs para a lista bought
        string boughtAsString = PlayerPrefs.GetString("BoughtItems", "");
        bought = ConvertStringToBoolList(boughtAsString);
    }

    private string ConvertBoolListToString(List<bool> list)
    {
        string result = "";
        for (int i = 0; i < list.Count; i++)
        {
            result += list[i] ? "1" : "0";
            if (i < list.Count - 1)
            {
                result += ",";
            }
        }
        return result;
    }

    private List<bool> ConvertStringToBoolList(string str)
    {
        List<bool> boolList = new List<bool>();
        string[] strArray = str.Split(',');

        for (int i = 0; i < strArray.Length; i++)
        {
            int intValue;
            if (int.TryParse(strArray[i], out intValue))
            {
                boolList.Add(intValue == 1);
            }
            else
            {
                boolList.Add(false);
            }
        }

        return boolList;
    }
}
