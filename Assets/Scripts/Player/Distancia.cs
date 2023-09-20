using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distancia : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public Text distanceText; // Refer�ncia ao objeto de texto

    private float initialPlayerPosition; // Posi��o inicial do jogador
    private int distance; // Dist�ncia percorrida pelo jogador

    void Start()
    {
        // Inicialize a posi��o inicial do jogador e a dist�ncia
        initialPlayerPosition = player.position.z;
        distance = 0;
    }

    void Update()
    {
        // Calcule a dist�ncia percorrida pelo jogador desde o in�cio do jogo
        distance = (int)(player.position.z - initialPlayerPosition);

        // Formate a dist�ncia com zeros � esquerda
        string formattedDistance = distance.ToString("D6"); // Isso formata com 6 d�gitos, adicionando zeros � esquerda

        // Atualize o texto do marcador de dist�ncia
        distanceText.text = formattedDistance;
    }
}
