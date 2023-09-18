using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FlashLightItem : MonoBehaviour
{
    public Light luz;
    public float flashlightRange;
    public LayerMask monsterLayer;
    public Slider batterySlider; // Referência ao Slider que representa a carga da bateria

    private float batteryCharge = 100.0f; // Capacidade inicial da bateria
    public float batteryConsumptionRate = 10.0f; // Taxa de consumo da bateria por segundo


    private void Start()
    {
        luz.enabled = false;
    }

    void Update()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            if (batteryCharge > 0)
            {
                FlashlightOn();
            }
        }

        if (Keyboard.current.gKey.wasReleasedThisFrame)
        {
            FlashlightOff();
        }

        // Consumir a bateria enquanto a lanterna estiver ligada
        if (luz.enabled)
        {
            batteryCharge -= batteryConsumptionRate * Time.deltaTime;
            UpdateBatteryFill();

            if (batteryCharge <= 0)
            {
                FlashlightOff();
            }
        }
            UpdateBatteryFill();
    }

    public void FlashlightOn()
    {
        if (batteryCharge > 0)
        {
            luz.enabled = true;
            DetectMonstersInRange();
        }
    }

    public void FlashlightOff()
    {
        luz.enabled = false;
    }

    public void DetectMonstersInRange()
    {
        Collider[] monstros = Physics.OverlapSphere(transform.position, flashlightRange, monsterLayer);

        foreach (var monstroCollider in monstros)
        {
            baseEnemy monstro = monstroCollider.GetComponent<baseEnemy>();

            if (monstro != null)
            {
                monstro.Morrer();
            }
        }
    }
    private void UpdateBatteryFill()
    {
        if (batterySlider != null)
        {
            float fillValue = batteryCharge / 100.0f; // Supondo que a carga máxima da bateria seja 100
            batterySlider.value = fillValue;
        }
    }
    public void RechargeBattery(float amount)
    {
        batteryCharge = Mathf.Clamp(batteryCharge + amount, 0.0f, 100.0f); // Limita a carga máxima da bateria a 100
        UpdateBatteryFill();
    }
}
