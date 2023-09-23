using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeDetection : MonoBehaviour
{
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Touch.PrimaryContact.started += OnPrimaryContactStarted;
    }

    private void OnDisable()
    {
        playerControls.Touch.PrimaryContact.started -= OnPrimaryContactStarted;
    }

    private void OnPrimaryContactStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Swipe detectado!");
        // Adicione aqui o código para mover o jogador para a direita ou esquerda.
    }
}
