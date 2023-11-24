using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Timers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Keyboard inputs
    public float horizontalInput;
    public float verticalInput;

    //Mouse controls
    public float mouseSensitivity = 100.0f;
    public float horizontalRotation;

    //boundary specifications
    public float speed = 10.0f; 
    public float xRange = 20.0f;

    //bullet obect reference for instantiation
    public GameObject projectilePrefab;
    public Rigidbody rigBod;

    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse controls
        //left click - for reload
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Debug.Log("Mouse 0 - Left Click");
        }
        //right click - for shoot
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            //UnityEngine.Debug.Log("Mouse 1 - Right Click");
        }
        //scroll wheel - for speedup
        if (Input.GetMouseButtonDown(2))
        {
            //speed = 20.0f;
            //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            //UnityEngine.Debug.Log("Mouse 2 - scroll wheel");
        }
        //scroll wheel - for speedup
        if (Input.GetMouseButtonDown(2))
        {

            //UnityEngine.Debug.Log("Mouse 2 - scroll wheel");
        }


        //check if player is withing bounds of play area and keep em there
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //mouse rotation
        horizontalRotation = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        transform.Rotate(Vector3.up, horizontalRotation);



        //Get Input from horizontal input from player
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //move ingame player obj - up, down, left and right
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        Vector3 move = transform.forward * verticalInput + transform.right * horizontalInput;
        rigBod.MovePosition(transform.position + move * speed * Time.deltaTime);
    }
}
