using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject storeMenu;




  
    public void OpenStoreMenu()
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);

    }

    public void OpenMainMenu()
    {
        storeMenu.SetActive(false);
        mainMenu.SetActive(true);

    }




}
