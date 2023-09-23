using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Pools
    {
        public string tag;
        public GameObject baseEnemy;
        public int size;
    }
    public Dictionary<string, Queue<GameObject>> baseEnemyPool;
    public List<Pools> pools;
   

    public GameObject enemyCommon;
    public GameObject player;
    public float spawnDistance;
    public float spawnCd;
    public float spawnBatteryCd;
    public float spawnPowerUpCd;
    public int batteryChance = 5;
    public int powerUpChance = 5;

    void Start()
    {
        baseEnemyPool = new Dictionary<string, Queue<GameObject>>();

        foreach (Pools pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.baseEnemy);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            baseEnemyPool.Add(pool.tag, objectPool);
        }

        InvokeRepeating("SpawnEnemy", 0, spawnCd);
        InvokeRepeating("Spawnbattery", spawnBatteryCd, spawnBatteryCd);
        InvokeRepeating("SpawnPowerUp", spawnPowerUpCd, spawnPowerUpCd);
    }

    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!baseEnemyPool.ContainsKey(tag))
        {
            Debug.LogWarning("Pool doesn't exist");
            return;
        }

        GameObject objToSpawn = baseEnemyPool[tag].Dequeue();

        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        objToSpawn.SetActive(true);

        // Reenfileira o objeto para ser reutilizado.
        baseEnemyPool[tag].Enqueue(objToSpawn);
    }

    public void SpawnEnemy()
    {
        Vector3 position = player.transform.position;
        position.z += spawnDistance;
        int randomNumber = UnityEngine.Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                position.x = -3.5f;
                break;

            case 2:
                position.x = 0;
                break;

            case 3:
                position.x = 3.5f;
                break;
        }

        
        SpawnFromPool("baseEnemy", position, Quaternion.identity);
    }

    public void Spawnbattery()
    {
        int chanceSpawn = UnityEngine.Random.Range(1, 11);
        if (chanceSpawn <= batteryChance)
        {

            


            Vector3 position = player.transform.position;
            position.z += spawnDistance;
            position.y = 0.005f;

            int randomNumber = UnityEngine.Random.Range(1, 4);


            switch (randomNumber)
            {
                case 1:
                    position.x = -3.5f;
                    break;

                case 2:
                    position.x = 0;
                    break;

                case 3:
                    position.x = 3.5f ;
                    break;
            }

            SpawnFromPool("battery", position, Quaternion.identity);

        }




        
    }


    public void SpawnPowerUp()
    {
        int chanceSpawn = UnityEngine.Random.Range(1, 11);
        if (chanceSpawn <= powerUpChance)
        {




            Vector3 position = player.transform.position;
            position.z += spawnDistance;
            position.y = 0.005f;

            int randomNumber = UnityEngine.Random.Range(1, 4);


            switch (randomNumber)
            {
                case 1:
                    position.x = -3.5f;
                    break;

                case 2:
                    position.x = 0;
                    break;

                case 3:
                    position.x = 3.5f;
                    break;
            }

            
            SpawnFromPool("powerUp", position, Quaternion.identity);

        }
    }
    }
