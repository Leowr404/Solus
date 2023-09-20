using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameWithCamera()
    {
        Debug.Log("startou com camera");
        SceneManager.LoadSceneAsync(1);
        PlayerPrefs.SetInt("ChosenItem", 1);
        

    }

    public void PlayGameWithFlashlight()
    {
        Debug.Log("Startou com lanterna");
        SceneManager.LoadSceneAsync(1);
        PlayerPrefs.SetInt("ChosenItem", 2);


    }

}
