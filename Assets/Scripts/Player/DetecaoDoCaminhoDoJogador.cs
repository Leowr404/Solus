using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecaoDoCaminhoDoJogador : MonoBehaviour
{
    public Transform jogador; // Referência ao jogador.

    private string caminhoAtual = "Caminho1"; // Caminho inicial do jogador.

    private void Update()
    {
        // Implemente sua lógica para determinar o caminho atual do jogador aqui.
        // Por exemplo, você pode usar raycasting ou outra técnica dependendo do seu jogo.

        // Para este exemplo, estamos apenas alterando aleatoriamente o caminho do jogador.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            caminhoAtual = EscolherCaminhoAleatorio();
            Debug.Log("Caminho Atual do Jogador: " + caminhoAtual);
        }
    }

    private string EscolherCaminhoAleatorio()
    {
        // Simplesmente como exemplo, escolha um caminho aleatório (1, 2 ou 3).
        int caminhoAleatorio = Random.Range(1, 4);
        return "Caminho" + caminhoAleatorio;
    }
}
