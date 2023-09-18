using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distancia : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public Text distanceText; // Referência ao objeto de texto

    private float initialPlayerPosition; // Posição inicial do jogador

    void Start()
    {
        // Registra a posição inicial do jogador
        initialPlayerPosition = player.position.z;
    }

    void Update()
    {
        // Calcule a distância percorrida pelo jogador
        float distance = player.position.z - initialPlayerPosition;

        // Atualize o texto do marcador de distância
        distanceText.text = distance.ToString("F0"); // "F0" formata para um número inteiro
    }
}
