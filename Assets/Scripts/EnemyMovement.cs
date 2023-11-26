using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float leftBound = -20f;
    public float rightBound = 20f;

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Move the enemy from left to right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Check if the enemy is out of bounds, and reverse its direction
        if (transform.position.x >= rightBound || transform.position.x <= leftBound)
        {
            speed = -speed;
        }
    }
}