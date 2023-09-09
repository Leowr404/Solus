using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public List<GameObject> GroundTiles = new List<GameObject>();
    private Vector3 nextSpawnPoint = Vector3.zero;
    private List<GameObject> bornTiles = new List<GameObject>(); //gambiarra


    public float moveTime = 5.0f;
    int currentIndex = 0, next = 3;
    public int moveRange = 150;
    

    void spawnTile()
{
    for (int i = 0; i < GroundTiles.Count; i++)
    {
        GameObject temp = Instantiate(GroundTiles[i], nextSpawnPoint, Quaternion.identity);
            bornTiles .Add(temp); //gambiarra
        // Atualize nextSpawnPoint para a posição do último objeto criado
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }
}


    
    void Start()
    {
        
            spawnTile();

        InvokeRepeating("moveTile", moveTime, moveTime);
      

    }

    void moveTile()
    {
       /* //tudo aqui embaixo eh gambiarra
        Vector3 position = bornTiles[currentIndex].transform.position;
        position.z += moveRange;

        bornTiles[currentIndex].transform.position = position;
;//tudo aqui encima eh gambiarra*/


        
        //ARRUMAR UM JEITO DISSO FUNCIONAR ' -'
       
        GameObject currentTile = bornTiles[currentIndex];

        int nextIndex =  next /*(currentIndex + 1) % bornTiles.Count*/;
        GameObject nextObject = bornTiles[next];

        Transform nextConnector = nextObject.transform.Find("ConectorFront");
        bornTiles[currentIndex].transform.position = nextConnector.transform.position;


        //ARRUMAR UM JEITO DO INDICE DO MAIOR SER PASSADO AUTOMATICAMENTE

        if (next != 3) next++;
        else next = 0;
        if(currentIndex != 3) currentIndex++;
        else currentIndex = 0;
        

    }


}
