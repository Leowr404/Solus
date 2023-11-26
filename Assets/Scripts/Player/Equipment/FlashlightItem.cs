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
        Debug.Log("Matando monstros");

    
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
            EnemyJumper jumperMonster = monsterCollider.GetComponent<EnemyJumper>();

            if (monster != null)
            {
                float monsterX = monster.transform.position.x;
                if (Mathf.Approximately(monsterX, transform.position.x - 0.558f) ||
                    (monsterX >= transform.position.x - 0.558f - 1f && monsterX <= transform.position.x - 0.558f + 1f))
                {
                    monster.Morrer();
                }
            }

            if (jumperMonster != null)
            {
                float jumperMonsterX = jumperMonster.transform.position.x;
                if (Mathf.Approximately(jumperMonsterX, transform.position.x - 0.558f) ||
                    (jumperMonsterX >= transform.position.x - 0.558f - 1f && jumperMonsterX <= transform.position.x - 0.558f + 1f))
                {
                    jumperMonster.Morrer();
                }
            }
        }
    }








}
