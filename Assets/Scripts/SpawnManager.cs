using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Enemy prefabs array
    public GameObject[] enemyPrefabs;

    // Enemy spawn locations array
    public Transform[] enemySpawnPoints;

    // Spawn interval in seconds
    private float spawnInterval = 2.5f;

    // Maximum number of enemies to spawn
    private int spawnMax = 10;

    // Maximum number of enemies on screen at once
    private int maxEnemiesOnScreen = 3;

    // List to keep track of active enemies
    private List<GameObject> activeEnemies = new List<GameObject>();

    // List to keep track of destroyed enemies
    private List<GameObject> destroyedEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Invoke a repeating function to spawn enemies at regular intervals
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally add any other logic you need in the Update method
    }

    void SpawnEnemy()
    {
        // Check if there are already maxEnemiesOnScreen active enemies and if the total spawned enemies are less than spawnMax
        if (activeEnemies.Count < maxEnemiesOnScreen && (activeEnemies.Count + destroyedEnemies.Count) < spawnMax)
        {
            // Select a random enemy prefab
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
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

        // Add the killed enemy to the list of destroyed enemies
        destroyedEnemies.Add(enemy);

        // Optionally add any other logic you need when an enemy is killed
    }

    // Function to get the list of destroyed enemies
    public List<GameObject> GetDestroyedEnemies()
    {
        return destroyedEnemies;
    }

    // Get a random spawn point from the predefined locations
    Transform GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, enemySpawnPoints.Length);
        return enemySpawnPoints[randomIndex];
    }
}
