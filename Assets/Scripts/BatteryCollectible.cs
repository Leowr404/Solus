using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatteryCol : MonoBehaviour
{
    public int rotationSpeed;
    private Vector3 rotate;
    public float rechargeAmountCamera = 20.0f; // Quantidade de recarga da câmera
    public float rechargeAmountFlashlight = 20.0f; // Quantidade de recarga da lanterna
    public LayerMask batteryLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlashLightItem flashlight = other.GetComponent<FlashLightItem>();
            CameraItem cameraItem = other.GetComponent<CameraItem>();
            Debug.Log("Colidido A Bateria Com o Player.");

            if (flashlight != null)
            {
                flashlight.RechargeBattery(rechargeAmountFlashlight);
            }
        }
    }









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
