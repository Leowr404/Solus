using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatteryCol : MonoBehaviour
{
    public int rotationSpeed;
    private Vector3 rotate;
    public float batteryChargeAmount = 20.0f; // Quantidade de recarga da câmera
    public float rechargeAmountFlashlight = 20.0f; // Quantidade de recarga da lanterna
    public LayerMask batteryLayer;
    public GameObject flashlight;


    void Start()
    {
        rotate = new Vector3(0,rotationSpeed,0);
    }

    
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);

    }


    public static void Recharge()
    {
        


    }

    
}
