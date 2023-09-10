using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriacaoDeCaminhos : MonoBehaviour
{
    public Transform caminhoPrefab; // Prefab do caminho a ser criado.

    private void Start()
    {
        // Crie os caminhos na cena.
        CriarCaminho("Caminho1", new Vector3(0f, 0f, 0f));
        CriarCaminho("Caminho2", new Vector3(0f, 0f, 10f));
        CriarCaminho("Caminho3", new Vector3(0f, 0f, 20f));
    }

    private void CriarCaminho(string nome, Vector3 posicao)
    {
        // Crie um novo objeto vazio para representar o caminho.
        Transform caminho = Instantiate(caminhoPrefab, posicao, Quaternion.identity);
        caminho.name = nome; // Defina o nome do objeto do caminho.
    }
}
