using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwipeTeste : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Velocidade de movimento
    public float laneWidth = 2.0f; // Largura de cada caminho

    private Vector3 targetPosition; // A posi��o para a qual o jogador deve se mover

    private void Start()
    {
        targetPosition = transform.position; // Inicialmente, o jogador fica na posi��o atual
    }

    private void Update()
    {
        // Move o jogador em dire��o � posi��o de destino
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Verifica se o jogador chegou � posi��o de destino
        if (transform.position == targetPosition)
        {
            // Se chegou � posi��o de destino, permite novo movimento
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Registra a posi��o inicial do toque
                    Vector2 startTouchPosition = touch.position;

                    if (startTouchPosition.x < Screen.width / 2)
                    {
                        // Swipe para a esquerda
                        MoveLeft();
                    }
                    else
                    {
                        // Swipe para a direita
                        MoveRight();
                    }
                }
            }
        }
    }

    private void MoveLeft()
    {
        // Move o jogador para a esquerda (um caminho � esquerda)
        targetPosition += Vector3.left * laneWidth;
    }

    private void MoveRight()
    {
        // Move o jogador para a direita (um caminho � direita)
        targetPosition += Vector3.right * laneWidth;
    }
}
    
