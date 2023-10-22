using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private static InventoryController instance;
    public GameObject storeNavigation;
    public List<bool> equipped;


    private StoreNavigation store;

   /* private void Awake()
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
    }*/

    void Start()
    {
        
        if (storeNavigation != null)
        {
            store = storeNavigation.GetComponent<StoreNavigation>();
        }

        // Carrega a lista de booleanos dos PlayerPrefs ao iniciar
        LoadItems();

        for(int i = 0; i < equipped.Count; i++) {
            Debug.Log(equipped[i]);
        }
    }

    public void CallSave()
    {
        SaveItems();
    }
    /*
    public void CallLoad()
    {
        LoadItems();
    }
    */

    private void SaveItems()
    {
        Debug.Log("salvar chamado");
        string equippedAsString = "";

        // Converte a lista de booleanos em uma string
        for (int i = 0; i < equipped.Count; i++)
        {
            equippedAsString += equipped[i] ? "1" : "0";

            // Adiciona uma vírgula, exceto para o último item
            if (i < equipped.Count - 1)
            {
                equippedAsString += ",";
            }
        }

        // Salva a string no PlayerPrefs
        PlayerPrefs.SetString("EquippedItems", equippedAsString);
        PlayerPrefs.Save();
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
                // Se não for possível converter para int, assume false
                equipped.Add(false);
            }
        }
    }

}