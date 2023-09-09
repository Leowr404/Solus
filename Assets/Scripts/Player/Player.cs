using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float gravity;

    private CharacterController characterController;
    private Vector3 velocity;
  //  private Touch touch;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        
    }

    void FixedUpdate()
    {
     /*   if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime,
                    transform.position.y,
                    transform.position.z
                );
            }
        }*/

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
