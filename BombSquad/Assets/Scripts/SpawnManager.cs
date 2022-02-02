using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyParent;
    public GameObject[] powerUpPrefab;
    public GameObject powerUpParent;

    public int spawnRange;
    public float spawnPositionRange;
    public int totalEnemyWaves;

    int wavecount;



    // Start is called before the first frame update
    void Start()
    {
        wavecount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyParent.transform.childCount == 0)
        {
            if (wavecount < totalEnemyWaves)
            {
                wavecount++;
                SpawnEnemyWave(spawnRange);
            }

        }
        if (powerUpParent.transform.childCount == 0)
                SpawnPowerUpWave(spawnRange);

    }

    void SpawnEnemyWave(int spawnRange)
    {
        for (int i = 0; i < spawnRange; i++)
            SpawnEnemy();
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPosition(), Quaternion.identity, enemyParent.transform);
    }

    void SpawnPowerUpWave(int spawnRange)
    {
        for (int i = 0; i < spawnRange; i++)
            SpawnPowerUp();
    }
    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab[PowerUpRandomizer()], SpawnPosition(), Quaternion.identity, powerUpParent.transform);
    }

    int PowerUpRandomizer()
    {
        return Random.Range(0, powerUpPrefab.Length);
    }
    Vector3 SpawnPosition()
    {
        float spawnX = Random.Range(-spawnPositionRange, spawnPositionRange);
        float spawnZ = Random.Range(-spawnPositionRange, spawnPositionRange);
        return new Vector3(spawnX, 0.5f, spawnZ);
    }
}
