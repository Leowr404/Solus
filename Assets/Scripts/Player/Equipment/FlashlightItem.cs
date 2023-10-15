using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Audio;

public class FlashLightItem : MonoBehaviour
{


    public Light luz;
    public float flashlightRange;
    public LayerMask monsterLayer;
   
    
    
   
    

    private void Start()
    {
        luz.enabled = false;
  

    }

    void Update()
    {
        

   

    }

    public void FlashlightOn()
    {
        

            luz.enabled = true;
        

        Invoke("DetectMonstersInRange", 0f);

    
    }

    public void FlashlightOff()
    {
       
        
        luz.enabled = false;
        
    }


    
    public void DetectMonstersInRange()
    {


        



        float radius = flashlightRange;
        Collider[] monsters = Physics.OverlapSphere(transform.position, radius, monsterLayer);

        foreach (var monsterCollider in monsters)
        {

            baseEnemy monster = monsterCollider.GetComponent<baseEnemy>();

            if (monster != null && Mathf.Approximately(monster.transform.position.x, transform.position.x -0.558f))
            {
                monster.Morrer();
            }

EnemyJumper jumperMonster = monsterCollider.GetComponent<EnemyJumper>();

            if (jumperMonster != null && Mathf.Approximately(jumperMonster.transform.position.x, transform.position.x - 0.558f))
            {
                jumperMonster.Morrer();
            }
        }




    }
    




   

}
