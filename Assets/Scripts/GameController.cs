using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public static GameController instance;

   
    public GameObject GameOverUI;
    public GameObject GameRunningUI;
    public GameObject GamePausedUI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        
    }



    private void Start()
    {
        GameOverUI.SetActive(false);
        GameRunningUI.SetActive(true);
        GamePausedUI.SetActive(false);

    }

    public void ActivateGameOverMenu()
    {
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
        GameRunningUI.SetActive(false);
    }

    public void PauseMenuOn()
    {
        Time.timeScale = 0f;
        GamePausedUI.SetActive(true);
        GameRunningUI.SetActive(false);
        





    }

    public void ResumeGame() 
    {
        Time.timeScale = 1f;
        GamePausedUI.SetActive(false);
        GameRunningUI.SetActive(true);
      



    }
    

}
