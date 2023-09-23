using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip somParaAtivar;

    void Update()
    {
        // Verifique se o bot�o desejado foi pressionado (por exemplo, tecla "A")
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAudio();
        }
    }

    public void PlayAudio()
    {
        // Verifique se a refer�ncia ao componente de �udio e o �udio para ativar foram definidos
        if (audioSource != null && somParaAtivar != null)
        {
            // Defina o �udio para reproduzir
            audioSource.clip = somParaAtivar;

            // Reproduza o �udio
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Refer�ncia ao AudioSource ou AudioClip n�o est�o definidos no script!");
        }
    }
}
