using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cenas : MonoBehaviour
{
    private static Cenas instance;

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
    }


}
