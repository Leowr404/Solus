using System.Collections.Generic;
using UnityEngine;

public class GerenciadorCaminhos : MonoBehaviour
{
    public List<GameObject> caminhosPrefabs = new List<GameObject>();

    private List<Transform> caminhosAtivos = new List<Transform>();
    private float distanciaReciclagem = 170f;
    private float distanciaEntreCaminhos = 300f;

    private void Start()
    {
        GerarCaminhosIniciais();
    }

    private void Update()
    {
        ReciclarCaminhos();
    }

    private void GerarCaminhosIniciais()
    {
        Vector3 posicaoInicial = Vector3.zero;

        for (int i = 0; i < caminhosPrefabs.Count; i++)
        {
            GameObject novoCaminho = Instantiate(caminhosPrefabs[i], posicaoInicial, Quaternion.identity);
            caminhosAtivos.Add(novoCaminho.transform);
            posicaoInicial += Vector3.forward * distanciaEntreCaminhos;
        }
    }

    private void ReciclarCaminhos()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");

        if (jogador == null)
            return; // Não encontrou o jogador com a tag "Player".

        if (caminhosAtivos.Count == 0)
            return;

        Transform primeiroCaminho = caminhosAtivos[0];
        float distanciaJogadorPrimeiroCaminho = jogador.transform.position.z - primeiroCaminho.position.z;

        if (distanciaJogadorPrimeiroCaminho > distanciaReciclagem)
        {
            // Mova o primeiro caminho para a frente.
            primeiroCaminho.position += Vector3.forward * (distanciaEntreCaminhos * caminhosPrefabs.Count);

            // Remova o primeiro caminho da lista e adicione-o ao final.
            caminhosAtivos.RemoveAt(0);
            caminhosAtivos.Add(primeiroCaminho);
        }
    }
}
