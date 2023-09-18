using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distancia : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public Text distanceText; // Refer�ncia ao objeto de texto

    private float initialPlayerPosition; // Posi��o inicial do jogador

    void Start()
    {
        // Registra a posi��o inicial do jogador
        initialPlayerPosition = player.position.z;
    }

    void Update()
    {
        // Calcule a dist�ncia percorrida pelo jogador
        float distance = player.position.z - initialPlayerPosition;

        // Atualize o texto do marcador de dist�ncia
        distanceText.text = distance.ToString("F0"); // "F0" formata para um n�mero inteiro
    }
}
