using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 30;
    private float spawnPosZ = 30;
    //private float spawnRangeY = 30;
    private float startDelay = 1.5f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnEnemy() 
    {
        //Random animal spawn
        int spawnCount = UnityEngine.Random.Range(0, enemyPrefabs.Length);

        //randomising position spawn
        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        //random location spawn positioning
        Instantiate(enemyPrefabs[spawnCount], spawnPos, enemyPrefabs[spawnCount].transform.rotation);
    }

}
