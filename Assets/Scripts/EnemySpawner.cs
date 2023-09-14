using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyCommon;
    public GameObject player;
    public float spawnDistance;
    public float spawnCd;
   

void Start()
    {
      
        InvokeRepeating("SpawnEnemy", 0, spawnCd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void SpawnEnemy()
    {
        
        Vector3 position = player.transform.position;
        position.z += spawnDistance;
        int randomNumber = UnityEngine.Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1: position.x = -10;
                break;

            case 2: position.x = 0; 
                break;

            case 3: position.x = 10;
                break;

        }

        GameObject newEnemy = Instantiate(enemyCommon, position, Quaternion.identity);


    }
}
