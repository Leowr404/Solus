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
    
   // public Slider sliderDeCarga; // Referência ao slider de carga no UI


   // public float cargaMaxima = 4;//100f; // Capacidade máxima da lanterna
    //public float cargaAtual; // Carga atual da lanterna
  //  public float taxaDeConsumo = 1f; // Taxa de consumo de carga por segundo

 //   private float batteryCharge = 100.0f; // Capacidade inicial da bateria
    //public float batteryConsumptionRate = 10.0f; // Taxa de consumo da bateria por segundo

    

    private void Start()
    {
        luz.enabled = false;
       // cargaAtual = cargaMaxima;
        //AtualizarSliderDeCarga();
    }

    void Update()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            // if (cargaAtual > 0)
            //  {
         
                FlashlightOn();
            

            //  }
        }

        if (Keyboard.current.gKey.wasReleasedThisFrame)
        {
          

            FlashlightOff();
        }

        // Consumir a bateria enquanto a lanterna estiver ligada
    //    if (luz.enabled)
    //    {
           // cargaAtual -= taxaDeConsumo * Time.deltaTime;
            

         //   if (batteryCharge <= 0)
           // {
        //        FlashlightOff();
        //    }
     //   }
        //AtualizarSliderDeCarga();

    }

    public void FlashlightOn()
    {
        
      //  if (batteryCharge > 0)
       // {
            luz.enabled = true;
        
        Invoke("DetectMonstersInRange", 0f);

        //}
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
   /* public void RecarregarLanterna(float quantidade)
    {
        // Método para recarregar a lanterna quando colidir com uma bateria
        cargaAtual += quantidade;
        cargaAtual = Mathf.Clamp(cargaAtual, 0, cargaMaxima);
        AtualizarSliderDeCarga();
    }*/

   /* private void AtualizarSliderDeCarga()
    {
        // Atualizar o valor do slider de carga no UI
        if (sliderDeCarga != null)
        {
            sliderDeCarga.value = cargaAtual / cargaMaxima;
        }
    }*/
   
}
