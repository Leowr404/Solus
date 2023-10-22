using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class InventoryGame : MonoBehaviour
{

    //0-lanterna
    //1-camera
    //2-lampiao
    //3-tocha
    //4-celular

    public List<GameObject> items;

    public List<bool> equipped;

    public ItensPlayer itensPlayer;
    
    void Awake()
    {


        GameObject itensPlayerObject = GameObject.Find("ItensController");
        if (itensPlayerObject != null)
        {
            itensPlayer = itensPlayerObject.GetComponent<ItensPlayer>();
            if (itensPlayer == null)
            {
                Debug.LogError("ItensPlayer not found!");
            }
        }
        
        LoadItems();
        EquipItems();
    }

    private void LoadItems()
    {
        // Carrega a string do PlayerPrefs
        string equippedAsString = PlayerPrefs.GetString("EquippedItems", "");

        // Converte a string de volta para uma lista de booleanos
        equipped = new List<bool>();
        string[] equippedArray = equippedAsString.Split(',');

        // Converte a string em uma lista de booleanos
        for (int i = 0; i < equippedArray.Length; i++)
        {
            int intValue;
            if (int.TryParse(equippedArray[i], out intValue))
            {
                equipped.Add(intValue == 1);
            }
            else
            {
                // Se nao for possível converter para int, assume false
                equipped.Add(false);
            }
        }
    }

    void EquipItems()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (equipped[i])
            {
                items[i].SetActive(true);
                

            }

        }

        if (equipped[0]) itensPlayer.whichItem = 2;
        else if (equipped[1])  itensPlayer.whichItem = 1;
            
       else { itensPlayer.whichItem = 2; } 

    }
}
