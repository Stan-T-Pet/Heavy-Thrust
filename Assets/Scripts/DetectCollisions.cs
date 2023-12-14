using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip playerBulletCollisionSound;
    public AudioClip enemyCollisionSound;
    
    void Start()
    {
        //get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Player collision logic here
            SceneManager.LoadScene("Lose"); //End of round load "Lose " scene

        }
        else if (other.gameObject.CompareTag("BS-Enemy") || other.gameObject.CompareTag("BS-Bullet"))
        {
            //when player bullet collides play sound
            PlayCollisionSound(playerBulletCollisionSound);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //when enemy bullet collides play sound
            PlayCollisionSound(enemyCollisionSound);

            //Destroy the collided object
            Destroy(gameObject);
        }
    }

    private void PlayCollisionSound(AudioClip sound)
    {
        if (sound != null && audioSource != null)
        {
            //Play the assigned sound
            audioSource.PlayOneShot(sound);
        }
    }
}
