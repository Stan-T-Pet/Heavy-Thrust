using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //enemy prefab
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 30;
    private float spawnPosZ = 30;
    private float spawnRangeY = 30;
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
        //max number of enemies spawnable on level = 9
        //spawn 3 enemies at scene start
        //when number of enemies fall bellow 3, spawn new enemy at random spawnLoc
        


        //SpawnCoount stores random value based on number of enemy variation
        int spawnCount = UnityEngine.Random.Range(0, enemyPrefabs.Length);

        //spawn position 
        Vector3 spawnPos = new Vector3();

        //random location spawn positioning
        Instantiate(enemyPrefabs[spawnCount], spawnPos, enemyPrefabs[spawnCount].transform.rotation);
    }

}
