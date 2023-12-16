using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if this is the player colliding with something
        if (gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("EnemyBullet")) // Example tag for enemy bullets
            {
                SceneManager.LoadScene("Lose");
                // Optionally, destroy the player or perform other actions
            }
        }

        // Check if this is an enemy being shot
        if (gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("PlayerBullet"))
        {
            FindObjectOfType<SpawnManager>().EnemyKilled(); // Increment the kill count
            Destroy(gameObject); // Destroy this enemy
        }
    }
}