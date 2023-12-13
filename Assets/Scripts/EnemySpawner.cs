using JetBrains.Annotations;
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


    [Header("Prefabs")]
    public GameObject enemyCommon;
    public GameObject player;

    [Header("Geral Configs")]
    public float spawnDistance;
    [Header("Enemies")]
    public float MainEnemyspawnCd;
    public float EnemyJumperCd;
    [Header("Battery")]
    public float spawnBatteryCd;
    public int batteryChance = 5;
    [Header("Power up")]
    public float spawnPowerUpCd;
    public int powerUpChance = 5;
    [Header("Coins")]
    public float coinSpawnDistance;
    public float spawnCoinCd;
    public int coinChance = 5;

    private int distanceAmongCoins = 4;


    //Gera todas as listas e pools, nao mexer
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

        InvokeRepeating("SpawnEnemy", 0, MainEnemyspawnCd);
        InvokeRepeating("SpawnEnemyJumper", EnemyJumperCd, EnemyJumperCd);
        InvokeRepeating("Spawnbattery", spawnBatteryCd, spawnBatteryCd);
        InvokeRepeating("SpawnPowerUp", spawnPowerUpCd, spawnPowerUpCd);
        InvokeRepeating("CoinSpawner", spawnCoinCd, spawnCoinCd);
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


        SpawnFromPool("baseEnemy", position, Quaternion.Euler(-90, 0, 0)); 
    }

    public void SpawnEnemyJumper()
    {
        Vector3 position = player.transform.position;
        position.z += spawnDistance;
        position.y -= 1.0f;
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

        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        SpawnFromPool("JumperEnemy", position, rotation);

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
            position.y = 0.945f;

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

    public void CoinSpawner()
    {
        //numero minimo de moedas que serao geradas em sequencia
        int coinsToSpawn = 3;
        bool continueSpawn = true;


        int chanceSpawn = UnityEngine.Random.Range(1, 11);
        if (chanceSpawn <= coinChance)
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

            


            SpawnFromPool("coin", position, Quaternion.identity);

            for(int i = 1; i < coinsToSpawn; i++)
            {
                position.z += distanceAmongCoins;

                SpawnFromPool("coin", position, Quaternion.identity);
            }

//depois de gerar o minimo de moedas esse while eh executado: 50% de gerar mais uma moeda e repetir o while, e 50% de nao gerar 
            while (continueSpawn)
            {
                randomNumber = UnityEngine.Random.Range(1, 3);

                if(randomNumber == 1)
                {
                    position.z += distanceAmongCoins;
                    SpawnFromPool("coin", position, Quaternion.identity);
                }
                else  continueSpawn = false; 


            }
        }
    }


}
