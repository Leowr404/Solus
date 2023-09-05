using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public List<GameObject> GroundTiles = new List<GameObject>(4);
    private Vector3 nextSpawnPoint = Vector3.zero;

    public float moveTime = 5.0f;
    int currentIndex = 0;

    void spawnTile()
{
    for (int i = 0; i < GroundTiles.Count; i++)
    {
        GameObject temp = Instantiate(GroundTiles[i], nextSpawnPoint, Quaternion.identity);

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
        //ARRUMAR UM JEITO DISSO FUNCIONAR ' -'
        Debug.Log("rodou");
        GameObject currentTile = GroundTiles[currentIndex];

        int nextIndex = (currentIndex + 1) % GroundTiles.Count;
        GameObject nextObject = GroundTiles[nextIndex];

        Transform nextConnector = nextObject.transform.Find("ConectorFront");


        //ARRUMAR UM JEITO DO INDICE DO MAIOR SER PASSADO AUTOMATICAMENTE

        if(currentIndex != 3) currentIndex++;
        else currentIndex = 0;
        Debug.Log("terminou de rodar");

    }


}
