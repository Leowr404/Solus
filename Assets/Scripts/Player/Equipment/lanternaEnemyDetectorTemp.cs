using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternaEnemyDetectorTemp : MonoBehaviour
{


    void OnTriggerStay(Collider other)
    {

        //arrumar depois isso aqui, só desativa o inimigo, mas n chama a função de morrer que ta dentro dele, tem que arrumar depois se precisar que o inimigo morra por ela
        // (e alem disso esse codigo aqui nem funciona ainda, how?!
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {


            other.gameObject.SetActive(false);

        }


    }
}
