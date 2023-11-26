using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization if needed
       // transform.forward = Vector3.forward;      
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

}