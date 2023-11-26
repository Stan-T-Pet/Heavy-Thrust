using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //Enemy prefabs array
    public GameObject[] enemyPrefabs;

    //Enemy spawn locations array
    public GameObject[] enemySpawnPoints;

    //Spawn interval in seconds
    private float spawnInterval = 2.5f;

    //Current spawn count
    private int spawnCount = 0;

    //Spawn delay in seconds
    private int spawnDelay = 2;

    //Maximum number of enemies to spawn on level
    private int spawnMax = 5;

    //Current enemy kill count
    private int killCount = 0;
    void Start()
    {
        //function repeats to spawn enemies at regular intervals
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
    }

    void Update()
    {
        //Checking if the spawn count is less than max
        if (spawnCount < spawnMax)
        {
            //Check if the kill count has reached the max
            if (killCount >= spawnMax)
            {
                //victory message
                UnityEngine.Debug.Log("End of Round - Victory!");
            }
            else
            { 
                spawnCount++;

                SpawnEnemy();//Spawn an enemy
            }
        }
    }

    //method to spawn an enemies
    void SpawnEnemy()
    {
        //Select random enemy prefab
        int enemyIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[enemyIndex];

        //find nxt enemy spawn point
        int spawnPointIndex = UnityEngine.Random.Range(0, enemySpawnPoints.Length);
        Vector3 spawnPos = enemySpawnPoints[spawnPointIndex].transform.position;

        //spawn the enemy prefab at the spawn position
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    //when an enemy is killed add to kill counter
    public void EnemyKilled()
    {
        
        killCount++;//add to count
        UnityEngine.Debug.Log("Enemies Killed: " + killCount);//msg

        // Check if the kill counter is  max
        if (killCount >= spawnMax)
        {
            UnityEngine.Debug.Log("Victory");
            SceneManager.LoadScene("Victory"); // End of round, load the next scene
        }
    }
}
