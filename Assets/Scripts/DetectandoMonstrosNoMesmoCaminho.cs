using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectandoMonstrosNoMesmoCaminho : MonoBehaviour
{
    public Transform jogador; // Referência ao jogador.
    public LayerMask monstrosLayer; // Camada dos monstros.

    void Start()
    {

    }


    private void Update()
    {
        // Implemente sua lógica de detecção de monstros no mesmo caminho aqui.
        // Use a posição do jogador e a posição dos monstros para determinar se estão no mesmo caminho.

        // Como exemplo, vamos supor que você tenha uma lista de monstros.
        /*MonstroController[] monstros = FindObjectsOfType<MonstroController>();

        foreach (MonstroController monstro in monstros)
        {
            // Obtenha a posição do monstro.
            Vector3 posicaoMonstro = monstro.transform.position;

            // Compare a posição do jogador com a posição do monstro para determinar se estão no mesmo caminho.
            if (EstaNoMesmoCaminho(jogador.position, posicaoMonstro))
            {
                // Faça algo com o monstro que está no mesmo caminho, por exemplo:
                monstro.Morrer();
            }
        }
    }

    private bool EstaNoMesmoCaminho(Vector3 posicaoJogador, Vector3 posicaoMonstro)
    {
        // Implemente sua lógica de determinação do mesmo caminho aqui.
        // Você pode usar colisões, raycasting ou outras técnicas dependendo do seu jogo.
        // Neste exemplo, estamos supondo que estão no mesmo caminho se estiverem na mesma coordenada X.

        return Mathf.Abs(posicaoJogador.x - posicaoMonstro.x) < 1.0f; // Exemplo de verificação simples.
    }*/
    }
}
