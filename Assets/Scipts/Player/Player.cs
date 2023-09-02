using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float gravity;

    private CharacterController characterController;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        ApplyGravity();
    }

    private void MovePlayer()
    {
        Vector3 frontMove = Vector3.forward * speed;
        characterController.Move(frontMove * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (characterController.isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
