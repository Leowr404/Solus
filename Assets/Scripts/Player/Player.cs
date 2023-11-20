using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public bool cheatOn;
    public GameObject itemObject;
    public float rechargeAmountFlashlight = 20.0f;
    public LayerMask batteryLayer;
    public GameObject FlashLightItem;
    public GameObject GameController;
    public GameObject CoinManager;
    public Transform player;

    public CoinTxt coinTxt;
    private int moedasColetadas = 0;


    public float speed = 5;
    public float gravity;

    private CharacterController characterController;
    private Vector3 velocity;

    private ItensPlayer itemScript;
    private GameController gameController;
    [SerializeField]
    private CoinController coinController;
    private AudioSource Coletavel;
    private AudioSource CoinCollect;
    private AudioSource Audio_PowerUp;
    


    private bool gameOver = false;
    

    void Start()
    {
        
        gameController = GameController.GetComponent<GameController>();
        itemScript = itemObject.GetComponent<ItensPlayer>();
        characterController = GetComponent<CharacterController>();
        
        Coletavel = AudioController.instancia.GetComponent<AudioSource>();
        CoinCollect = AudioController.instancia.GetComponent<AudioSource>();
        CoinCollect = AudioController.instancia.GetComponent<AudioSource>();
        
        




    }

    void Update()
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

            Coletavel.PlayOneShot(AudioController.instancia.Audio_Coletavel, 1f);
            itemScript.CompleteBatteryReload();
 

            other.gameObject.SetActive(false);

        }


        //da pra fazer o gameOver ou a referencia pro script que vai rodar ele apartir daqui 
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            if (cheatOn == false) { 
            gameOver = true;
            this.gameObject.SetActive(false);
            gameController.ActivateGameOverMenu();
            }
            else other.gameObject.SetActive(false);
            

        }
        
        

        if (other.gameObject.layer == LayerMask.NameToLayer("PowerUp"))
        {

            Debug.Log("Coletou Power up");


            StartCoroutine(itemScript.PowerUpInfiniteBattery());
            other.gameObject.SetActive(false);

            Audio_PowerUp.PlayOneShot(AudioController.instancia.Audio_PowerUp, 1f); 


        }


        if (other.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            ColetarMoeda(other.gameObject);
            coinController.CollectCoin();
            CoinCollect.PlayOneShot(AudioController.instancia.CoinCollect, 1f);
            other.gameObject.SetActive(false);

        }

    }
    void ColetarMoeda(GameObject moeda)
    {
        moedasColetadas++;
        coinTxt.AtualizarMoedas(moedasColetadas);
    }








}
