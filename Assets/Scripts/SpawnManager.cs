using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Enemy prefabs array
    public GameObject[] enemyPrefabs;

    // Enemy spawn locations array
    public Transform[] enemySpawnPoints;

    // Spawn interval in seconds
    private float spawnInterval = 2.5f;

    // Current spawn count
    private int spawnCount = 0;

    // Spawn delay in seconds
    private int spawnDelay = 2;

    // Maximum number of enemies to spawn
    private int spawnMax = 10;

    // Current enemy kill count
    private int killCount = 0;

    // Maximum number of enemies on screen at once
    private int maxEnemiesOnScreen = 3;

    // List to keep track of active enemies
    private List<GameObject> activeEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Invoke a repeating function to spawn enemies at regular intervals
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the spawn count is less than the maximum spawn count
        if (spawnCount < spawnMax)
        {
            // Check if the kill count has reached the maximum
            if (killCount >= spawnMax)
            {
                // End the round and print a victory message
                UnityEngine.Debug.Log("End of Round - Victory!");
            }
            else
            {
                // Increment the spawn count
                spawnCount++;

                // Spawn an enemy
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        // Check if there are already maxEnemiesOnScreen active enemies
        if (activeEnemies.Count < maxEnemiesOnScreen)
        {
            // Select a random enemy prefab
            int enemyIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[enemyIndex];

            // Get the next enemy spawn point
            Transform spawnPoint = GetRandomSpawnPoint();

            // Instantiate the enemy prefab at the spawn position
            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Add the spawned enemy to the list of active enemies
            activeEnemies.Add(enemyInstance);
        }
    }

    // Function to be called when an enemy is killed
    public void EnemyKilled(GameObject enemy)
    {
        // Remove the killed enemy from the list of active enemies
        activeEnemies.Remove(enemy);

        // Increment the kill count
        killCount++;

        // Check if the kill count has reached the maximum
        if (killCount >= spawnMax)
        {
            // End the round and print a victory message
            UnityEngine.Debug.Log("End of Round - Victory!");
        }
    }

    // Get a random spawn point from the predefined locations
    Transform GetRandomSpawnPoint()
    {
        int randomIndex = UnityEngine.Random.Range(0, enemySpawnPoints.Length);
        return enemySpawnPoints[randomIndex];
    }
}
