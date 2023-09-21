using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text mensagemText;
    public float tempoExibicao = 2f;

    private void Start()
    {
        mensagemText.gameObject.SetActive(false);
    }

    public void ExibirMensagem(string mensagem)
    {
        StartCoroutine(ExibirMensagemPorTempo(mensagem));
    }

    private IEnumerator ExibirMensagemPorTempo(string mensagem)
    {
        // Define o texto da mensagem
        mensagemText.text = mensagem;

        // Ativa o texto da mensagem
        mensagemText.gameObject.SetActive(true);

        // Aguarda o tempo especificado
        yield return new WaitForSeconds(tempoExibicao);

        // Desativa o texto da mensagem após o tempo especificado
        mensagemText.gameObject.SetActive(false);
    }
    public void PlayGameWithCamera()
    {
        Debug.Log("Camera Selected");
        //SceneManager.LoadSceneAsync(1);
        PlayerPrefs.SetInt("ChosenItem", 1);
        

    }

    public void PlayGameWithFlashlight()
    {
        Debug.Log("Flashlight Selected");
        //SceneManager.LoadSceneAsync(1);
        PlayerPrefs.SetInt("ChosenItem", 2);


    }

}
