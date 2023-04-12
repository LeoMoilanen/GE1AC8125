using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

// I made this script with the help of this tutorial: https://www.youtube.com/watch?v=pKN8jVnSKyM&ab_channel=ChronoABI
public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    [SerializeField] private Wave currentWave;
    [SerializeField] private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    public bool gameWon;

    private int wavesKilled;

    private void Start()
    {
        Debug.Log("maximum wave length: " + waves.Length);
    }

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber+1 != waves.Length)
        {
            currentWaveNumber++;
            canSpawn = true;
        }

        if (totalEnemies.Length == 0 && wavesKilled == 3)
        {
            Debug.Log("All enemies killed");
            gameWon = true;
        }
    }

    private void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            
            if (currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
                wavesKilled += 1;
            }
        }
    }
}
