using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectandoMonstrosNoMesmoCaminho : MonoBehaviour
{
    public Transform jogador; // Refer�ncia ao jogador.
    public LayerMask monstrosLayer; // Camada dos monstros.

    void Start()
    {

    }


    private void Update()
    {
        // Implemente sua l�gica de detec��o de monstros no mesmo caminho aqui.
        // Use a posi��o do jogador e a posi��o dos monstros para determinar se est�o no mesmo caminho.

        // Como exemplo, vamos supor que voc� tenha uma lista de monstros.
        /*MonstroController[] monstros = FindObjectsOfType<MonstroController>();

        foreach (MonstroController monstro in monstros)
        {
            // Obtenha a posi��o do monstro.
            Vector3 posicaoMonstro = monstro.transform.position;

            // Compare a posi��o do jogador com a posi��o do monstro para determinar se est�o no mesmo caminho.
            if (EstaNoMesmoCaminho(jogador.position, posicaoMonstro))
            {
                // Fa�a algo com o monstro que est� no mesmo caminho, por exemplo:
                monstro.Morrer();
            }
        }
    }

    private bool EstaNoMesmoCaminho(Vector3 posicaoJogador, Vector3 posicaoMonstro)
    {
        // Implemente sua l�gica de determina��o do mesmo caminho aqui.
        // Voc� pode usar colis�es, raycasting ou outras t�cnicas dependendo do seu jogo.
        // Neste exemplo, estamos supondo que est�o no mesmo caminho se estiverem na mesma coordenada X.

        return Mathf.Abs(posicaoJogador.x - posicaoMonstro.x) < 1.0f; // Exemplo de verifica��o simples.
    }*/
    }
}
