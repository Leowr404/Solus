using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distancia : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public Text distanceText; // Referência ao objeto de texto

    private float initialPlayerPosition; // Posição inicial do jogador
    private int distance; // Distância percorrida pelo jogador

    void Start()
    {
        // Inicialize a posição inicial do jogador e a distância
        initialPlayerPosition = player.position.z;
        distance = 0;
    }

    void Update()
    {
        // Calcule a distância percorrida pelo jogador desde o início do jogo
        distance = (int)(player.position.z - initialPlayerPosition);

        // Formate a distância com zeros à esquerda
        string formattedDistance = distance.ToString("D6"); // Isso formata com 6 dígitos, adicionando zeros à esquerda

        // Atualize o texto do marcador de distância
        distanceText.text = formattedDistance;
    }
}
