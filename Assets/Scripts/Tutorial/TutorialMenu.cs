using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TutorialGame;

public class TutorialMenu : MonoBehaviour
{
    public TutorialPanel[] tutorialPanels;
    private int currentPanelIndex = 0;
    public float typingSpeed = 0.05f;

    private bool tutorialCompleted = false;

    void Start()
    {
        tutorialCompleted = PlayerPrefs.HasKey("TutorialCompleted");

        if (!tutorialCompleted)
        {
            ShowCurrentPanel();
        }
        else
        {
            // Se já foi concluído, desativa todos os painéis
            foreach (var panel in tutorialPanels)
            {
                panel.panelObject.SetActive(false);
            }
        }
    }

    void ShowCurrentPanel()
    {
        if (currentPanelIndex < tutorialPanels.Length)
        {
            tutorialPanels[currentPanelIndex].panelObject.SetActive(true);

            // Se for o painel atual, exibe o diálogo
            StartCoroutine(TypeDialogue(tutorialPanels[currentPanelIndex].dialogueText, tutorialPanels[currentPanelIndex].dialogue));
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
        if (!tutorialCompleted && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            NextPanel();
        }
    }

    public void NextPanel()
    {
        if (!tutorialCompleted)
        {
            tutorialPanels[currentPanelIndex].panelObject.SetActive(false);
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
    }

    void EndTutorial()
    {
        Debug.Log("Tutorial concluído!");

        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save(); // Certifica-se de salvar imediatamente
    }

    public void RestartTutorial()
    {
        // Limpa a chave de PlayerPrefs
        PlayerPrefs.DeleteKey("TutorialCompleted");

        // Reinicia o tutorial
        currentPanelIndex = 0;
        Start();
    }
}
