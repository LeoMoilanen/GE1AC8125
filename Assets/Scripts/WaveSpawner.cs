using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private Wave currentWave;
    [SerializeField] private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    public bool gameWon;
    [SerializeField] private int wavesLeft;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject victoryPicture;
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject wavesText;

    [SerializeField] private GameObject battleMusic;
    [SerializeField] private GameObject victoryMusic;

    [SerializeField] private Text wavesLeftText;


    private void Start()
    {
        victoryPicture.gameObject.SetActive(false);
    }

    private void Update()
    {
        wavesLeftText.text = "Waves left " + wavesLeft.ToString();

        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn && !gameWon)
        {
            wavesLeft -= 1;

            if (currentWaveNumber + 1 != waves.Length)
            {
                currentWaveNumber++;
                canSpawn = true;
            }
            
        }

        if (totalEnemies.Length == 0 && wavesLeft == 0)
        {
            Debug.Log("All enemies killed");
            gameWon = true;
        }

        if (gameWon)
        {
            player.gameObject.SetActive(false);
            victoryPicture.gameObject.SetActive(true);
            battleMusic.gameObject.SetActive(false);
            victoryMusic.gameObject.SetActive(true);
            victoryText.gameObject.SetActive(true);
            wavesText.gameObject.SetActive(false);
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
                
            }
        }
    }
}
