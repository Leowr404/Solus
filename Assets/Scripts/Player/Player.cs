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
    public GameObject CoinManager;
    public Transform player;

    public float speed = 5;
    public float gravity;

    private CharacterController characterController;
    private Vector3 velocity;

    private ItensPlayer itemScript;
    private GameController gameController;
    private CoinController coinController;
    private AudioSource Coletavel;

    

    private bool gameOver = false;
    //  private Touch touch;

    void Start()
    {
        
        gameController = GameController.GetComponent<GameController>();
        itemScript = itemObject.GetComponent<ItensPlayer>();
        characterController = GetComponent<CharacterController>();
        coinController = CoinManager.GetComponent<CoinController>();
        Coletavel = AudioController.instancia.GetComponent<AudioSource>();


    }

    void Update()
    {
       

        MovePlayer();
        ApplyGravity();

      /*  if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            ChangePath(3.5f);
        }*/
    }


    private void MovePlayer()
    {
        Vector3 frontMove = Vector3.forward * speed;
        characterController.Move(frontMove * Time.deltaTime);
    }

    /*public void ChangePath(float distance)
    {
        Debug.Log("mudar trilha chamado");
        player.position = new Vector3(player.position.x + distance, player.position.y, player.position.z);


    }*/

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

            Coletavel.PlayOneShot(AudioController.instancia.Audio_Coletavel, 1f);
            itemScript.CompleteBatteryReload();
 

            other.gameObject.SetActive(false);

        }
        

        //da pra fazer o gameOver ou a referencia pro script que vai rodar ele apartir daqui 
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {

            gameOver = true;
            this.gameObject.SetActive(false);
            gameController.ActivateGameOverMenu();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("PowerUp"))
        {
            
            other.gameObject.SetActive(false);
            
            StartCoroutine(itemScript.PowerUpInfiniteBattery());



        }


        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            other.gameObject.SetActive(false);
            coinController.coin++;





        }

        }

    
}
