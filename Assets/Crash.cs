using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip somParaAtivar;

    void Update()
    {
        // Verifique se o botão desejado foi pressionado (por exemplo, tecla "A")
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAudio();
        }
    }

    public void PlayAudio()
    {
        // Verifique se a referência ao componente de áudio e o áudio para ativar foram definidos
        if (audioSource != null && somParaAtivar != null)
        {
            // Defina o áudio para reproduzir
            audioSource.clip = somParaAtivar;

            // Reproduza o áudio
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Referência ao AudioSource ou AudioClip não estão definidos no script!");
        }
    }
}
