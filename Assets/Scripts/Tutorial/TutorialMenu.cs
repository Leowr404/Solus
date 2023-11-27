using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public GameObject[] tutorialPanels;
    private int currentPanelIndex = 0;
    public GameObject[] tutorialDialogues;
    private int currentDialogueIndex = 0;


    void Start()
    {
        ShowCurrentPanel();
    }

    void ShowCurrentPanel()
    {
        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            tutorialPanels[i].SetActive(i == currentPanelIndex);
            
        }
    }

    void Update()
    {
        // Verifica se houve um toque na tela
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Conduz para o pr�ximo painel do tutorial
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
        Debug.Log("Tutorial conclu�do!");

        // Salva que o tutorial foi conclu�do para n�o exibir novamente
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save();
        

        // Adicione aqui qualquer l�gica para o que voc� quer fazer ap�s o tutorial.
    }
}
