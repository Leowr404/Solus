using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FlashLightItem : MonoBehaviour
{


    public Light luz;
    public float flashlightRange;
    public LayerMask monsterLayer;
    public GameObject collider;
    
   
    

    private void Start()
    {
        luz.enabled = false;
  

    }

    void Update()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
          
         
                FlashlightOn();
            

 
        }

        if (Keyboard.current.gKey.wasReleasedThisFrame)
        {
          

            FlashlightOff();
        }

   

    }

    public void FlashlightOn()
    {
       // collider.SetActive(true);

            luz.enabled = true;
        

        Invoke("DetectMonstersInRange", 0f);

    
    }

    public void FlashlightOff()
    {
        //collider.SetActive(false);
        
        luz.enabled = false;
        
    }

    public void DetectMonstersInRange()
    {





        
        float radius = flashlightRange; // Raio no eixo Z

        Vector3 center = transform.position;
        center.x = center.y = 0f; // Defina as coordenadas X e Y como zero para restringir a detecção ao eixo Z

        Collider[] monsters = Physics.OverlapSphere(center, radius, monsterLayer);

        foreach (var monsterCollider in monsters)
        {
            baseEnemy monster = monsterCollider.GetComponent<baseEnemy>();

            if (monster != null)
            {
                monster.Morrer();
            }
        }
    }
    




   

}
