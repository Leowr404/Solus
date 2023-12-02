using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cenas : MonoBehaviour
{
    private static Cenas instance;
    public static bool TutorialCompleted { get; private set; } = false;
    void Start()
    {
        // Carrega o estado do tutorial ao iniciar o jogo
        TutorialCompleted = PlayerPrefs.HasKey("TutorialGameCompleted");
    }
    public static void CompleteTutorial()
    {
        // Marca o tutorial como conclu�do
        TutorialCompleted = true;

        // Salva o estado do tutorial
        PlayerPrefs.SetInt("TutorialGameCompleted", 1);
        PlayerPrefs.Save();
    }



    private void Awake()
    {
        // Garante que apenas uma inst�ncia do SceneController exista na cena
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
        if (TutorialCompleted)
        {
            SceneManager.LoadSceneAsync(1);
            Time.timeScale = 1.0f;
        }
        else
        {
            SceneManager.LoadSceneAsync(2);
            Time.timeScale = 1.0f;
        }
    }


    public void CarregarMenu()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1.0f;
    }


}
