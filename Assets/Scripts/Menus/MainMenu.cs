using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject creditsMenu;




  
    public void OpenStoreMenu()
    {
        
        storeMenu.SetActive(true);

    }

    public void CloseStoreMenu()
    {
        
        storeMenu.SetActive(false);

    }

    public void OpenMainMenu()
    {
        storeMenu.SetActive(false);
        mainMenu.SetActive(true);

    }

    public void OpenCreditsMenu()
    {
        creditsMenu.SetActive(true);
    }

    public void CloseCredisMenu()
    {
        creditsMenu.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif

    }




}
