using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGame : MonoBehaviour
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

    private bool isTyping = false;
    private bool isTutorialActive = true;

    void Start()
    {
        if (!PlayerPrefs.HasKey("TutorialCompleted"))
        {
            StartCoroutine(ShowTutorial());
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

    IEnumerator ShowTutorial()
    {
        while (currentPanelIndex < tutorialPanels.Length)
        {
            Time.timeScale = isTutorialActive ? 0 : 1;

            var panel = tutorialPanels[currentPanelIndex];
            panel.panelObject.SetActive(true);

            if (!isTyping)
            {
                yield return StartCoroutine(TypeDialogue(panel.dialogueText, panel.dialogue));
            }

            panel.panelObject.SetActive(false);
            Time.timeScale = 1;

            yield return new WaitForSeconds(0.1f); // Pequeno atraso para evitar problemas de entrada
            currentPanelIndex++;
        }

        // Fim do tutorial
        EndTutorial();
    }

    IEnumerator TypeDialogue(Text textObject, string dialogue)
    {
        isTyping = true;
        textObject.text = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            textObject.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (isTutorialActive)
            {
                NextPanel();
            }
            else
            {
                // Lidar com a entrada durante o jogo normal
            }
        }
    }

    void NextPanel()
    {
        if (currentPanelIndex < tutorialPanels.Length)
        {
            StartCoroutine(ShowTutorial());
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

        isTutorialActive = false;
        foreach (var panel in tutorialPanels)
        {
            panel.panelObject.SetActive(false);
        }
    }

    public void RestartTutorial()
    {
        // Limpa a chave de PlayerPrefs
        PlayerPrefs.DeleteKey("TutorialCompleted");

        // Reinicia o tutorial
        currentPanelIndex = 0;
        isTutorialActive = true;
        Start();
    }
}
