using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject itemObject;
    public float rechargeAmountFlashlight = 20.0f;
    public LayerMask batteryLayer;
    public GameObject FlashLightItem;
    public GameObject GameController;

    public float speed = 5;
    public float gravity;

    private CharacterController characterController;
    private Vector3 velocity;

    private ItensPlayer itemScript;
    private GameController gameController;

    

    private bool gameOver = false;
    //  private Touch touch;

    void Start()
    {
        
        gameController = GameController.GetComponent<GameController>();
        itemScript = itemObject.GetComponent<ItensPlayer>();
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

    void OnTriggerStay(Collider other)
    {
        

        if (other.gameObject.layer == LayerMask.NameToLayer("Collectible"))
        {
            Debug.Log("colidiu com player");
            itemScript.CompleteBatteryReload();
            Debug.Log("colidiu");

            other.gameObject.SetActive(false);

        }
        

        //da pra fazer o gameOver ou a referencia pro script que vai rodar ele apartir daqui 
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Debug.Log("Colidiu com inimigo");
            gameOver = true;
            this.gameObject.SetActive(false);
            gameController.ActivateGameOverMenu();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("PowerUp"))
        {
            
            other.gameObject.SetActive(false);
            
            StartCoroutine(itemScript.PowerUpInfiniteBattery());



        }

        }

    
}
