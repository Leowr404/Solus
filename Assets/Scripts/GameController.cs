using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public static GameController instance;

    public GameObject Player;
    public GameObject GameOverUI;
    public GameObject GameRunningUI;

    //    cameraItemScript = CameraGO.GetComponent<CameraItem>();
    //  private CameraItem cameraItemScript;

    private Player playerScript;

    private void Start()
    {
        playerScript = Player.GetComponent<Player>();
    }

    public void ActivateGameOverMenu()
    {
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
        GameRunningUI.SetActive(false);

    }


    public void Restart()
    {

        string currentSceneName = SceneManager.GetActiveScene().name;


        SceneManager.LoadScene(currentSceneName);

    }

}
