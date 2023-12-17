using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cenas : MonoBehaviour
{
    public static Cenas instance;
    public static bool TutorialCompleted { get; private set; } = false;
    
    public static void CompleteTutorial()
    {
        // Marca o tutorial como concluído
        TutorialCompleted = true;

        // Salva o estado do tutorial
        PlayerPrefs.SetInt("TutorialGameCompleted", 1);
        PlayerPrefs.Save();
    }



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
    public void CarregarJogo()
    {
        
            SceneManager.LoadSceneAsync(1);
            Time.timeScale = 1.0f;
       
    }


    public void CarregarMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1.0f;
    }
    public void RestartTutorial()
    {
        PlayerPrefs.DeleteKey("TutorialGameCompleted");
        
        PlayerPrefs.Save();
        TutorialCompleted = false;
        

    }


}
