using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private static InventoryController instance;
    public GameObject storeNavigation;
    public List<bool> bought;

    private StoreNavigation store;

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

    void Start()
    {
        if (storeNavigation != null)
        {
            store = storeNavigation.GetComponent<StoreNavigation>();

        }
    }
}