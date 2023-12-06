using System.Collections.Generic;
using UnityEngine;

public class GerenciadorCaminhos : MonoBehaviour
{
    public List<GameObject> caminhosPrefabs = new List<GameObject>();
    public List<GameObject> cenariosPrefabs = new List<GameObject>(); // Adiciona os prefabs dos cenários laterais aqui.

    private List<Transform> caminhosAtivos = new List<Transform>();
    private List<Transform> cenariosAtivos = new List<Transform>(); // Lista para rastrear os cenários laterais.

    private float distanciaReciclagem = 170f;
    private float distanciaEntreCaminhos = 300f;

    private void Start()
    {
        GerarCaminhosIniciais();
        GerarCenariosIniciais(); // Adiciona a geração dos cenários iniciais.
    }

    private void Update()
    {
        ReciclarCaminhos();
        ReciclarCenarios(); // Adiciona a reciclagem dos cenários laterais.
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

    private void GerarCenariosIniciais()
    {
        Vector3 posicaoInicialGerador = new Vector3(-4.5f, 1.97f, 13.06f);
        Vector3 posicaoAtual = posicaoInicialGerador;
        // Gera os cenários laterais iniciais.
        for (int i = 0; i < cenariosPrefabs.Count; i++)
        {
            GameObject novoCenario = Instantiate(cenariosPrefabs[i], posicaoAtual, Quaternion.identity);
            cenariosAtivos.Add(novoCenario.transform);
            posicaoAtual += Vector3.forward * distanciaEntreCaminhos;
        }
    }

    private void ReciclarCaminhos()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");

        if (jogador == null)
            return;

        if (caminhosAtivos.Count == 0)
            return;

        Transform primeiroCaminho = caminhosAtivos[0];
        float distanciaJogadorPrimeiroCaminho = jogador.transform.position.z - primeiroCaminho.position.z;

        if (distanciaJogadorPrimeiroCaminho > distanciaReciclagem)
        {
            primeiroCaminho.position += Vector3.forward * (distanciaEntreCaminhos * caminhosPrefabs.Count);
            caminhosAtivos.RemoveAt(0);
            caminhosAtivos.Add(primeiroCaminho);
        }
    }

    private void ReciclarCenarios()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");

        if (jogador == null)
            return;

        if (cenariosAtivos.Count == 0)
            return;

        Transform primeiroCenario = cenariosAtivos[0];
        float distanciaJogadorPrimeiroCenario = jogador.transform.position.z - primeiroCenario.position.z;

        // Lógica de reciclagem para os cenários laterais.
        if (distanciaJogadorPrimeiroCenario > distanciaReciclagem)
        {
            primeiroCenario.position += Vector3.forward * (distanciaEntreCaminhos * caminhosPrefabs.Count);
            cenariosAtivos.RemoveAt(0);
            cenariosAtivos.Add(primeiroCenario);
        }
    }
}
