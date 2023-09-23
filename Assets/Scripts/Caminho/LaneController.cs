using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    public float laneWidth = 3.5f; // Largura de cada caminho
    private int currentLane = 1; // Começa no caminho do meio (0, 1, 2 representam os caminhos)

    private void Start()
    {
        // Defina a posição inicial do jogador com base no caminho atual
        SetLanePosition(currentLane);
    }

    public void ChangeLane(int newLane)
    {
        // Certifique-se de que o novo caminho esteja dentro dos limites
        newLane = Mathf.Clamp(newLane, 0, 2); // 0, 1 e 2 representam os caminhos

        // Calcule a nova posição X com base no caminho escolhido
        float targetX = (newLane - 1) * laneWidth;

        // Atualize a posição do jogador
        SetLanePosition(newLane);
    }

    private void SetLanePosition(int lane)
    {
        float targetX = (lane - 1) * laneWidth;
        Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = newPosition;

        currentLane = lane;
    }
}
