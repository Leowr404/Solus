using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGame1 : MonoBehaviour
{
    public List<Text> tutorialTexts;
    public float typingSpeed = 0.1f; // Velocidade de digita��o
    public float displayTime = 3f; // Tempo de exibi��o de cada mensagem
    private int currentMessageIndex = 0;
    private bool tutorialCompleted = false;

    void Start()
    {
        // Verifica se o tutorial j� foi conclu�do
        tutorialCompleted = PlayerPrefs.GetInt("TutorialCompleted", 0) == 1;

        if (!tutorialCompleted)
        {
            ShowTutorial();
        }
    }

    void ShowTutorial()
    {
        StartCoroutine(ShowTutorialCoroutine());
    }

    IEnumerator ShowTutorialCoroutine()
    {
        yield return new WaitForSeconds(1f); // Atraso inicial se necess�rio

        foreach (Text textObject in tutorialTexts)
        {
            yield return TypeDialogue(textObject, textObject.text);
            yield return new WaitForSeconds(displayTime);
            textObject.gameObject.SetActive(false);
        }

        // Tutorial conclu�do, pode salvar que o tutorial foi exibido
        PlayerPrefs.SetInt("TutorialCompleted", 1);
    }

   public void ResetTutorial()
    {
        StopAllCoroutines();

        foreach (Text textObject in tutorialTexts)
        {
            textObject.gameObject.SetActive(false);
        }

        currentMessageIndex = 0;
        ShowTutorial();
    }

    IEnumerator TypeDialogue(Text textObject, string dialogue)
    {
        textObject.text = "";
        textObject.gameObject.SetActive(true);

        foreach (char letter in dialogue.ToCharArray())
        {
            textObject.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Aguarda um tempo adicional ap�s a digita��o para garantir que o jogador possa ler a mensagem completa
        yield return new WaitForSeconds(1f);
    }   
}
