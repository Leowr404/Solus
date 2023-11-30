using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    [System.Serializable]
    public class TutorialPanel
    {
        public GameObject panelObject;
        public Text dialogueText;
        public string dialogue;
    }

    public TutorialPanel[] tutorialPanels;
    private int currentPanelIndex = 0;
    public float typingSpeed = 0.05f;

    void Start()
    {
        ShowCurrentPanel();
    }

    void ShowCurrentPanel()
    {
        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            tutorialPanels[i].panelObject.SetActive(i == currentPanelIndex);

            // Se for o painel atual, exibe o diálogo
            if (i == currentPanelIndex)
            {
                StartCoroutine(TypeDialogue(tutorialPanels[i].dialogueText, tutorialPanels[i].dialogue));
            }
        }
    }

    IEnumerator TypeDialogue(Text textObject, string dialogue)
    {
        textObject.text = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            textObject.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            NextPanel();
        }
    }

    public void NextPanel()
    {
        currentPanelIndex++;

        if (currentPanelIndex < tutorialPanels.Length)
        {
            ShowCurrentPanel();
        }
        else
        {
            EndTutorial();
        }
    }

    void EndTutorial()
    {
        Debug.Log("Tutorial concluído!");

        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save();
    }
}
