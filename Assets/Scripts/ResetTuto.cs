using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTuto : MonoBehaviour
{
    public void RestartTutorial()
    {
        PlayerPrefs.DeleteKey("TutorialGameCompleted");
        PlayerPrefs.DeleteKey("TutorialGameCompleted");
        PlayerPrefs.DeleteKey("TutorialGameCompleted");

    }
}
