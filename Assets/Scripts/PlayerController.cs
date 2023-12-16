using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Keyboard inputs
    private float horizontalInput;
    private float verticalInput; 
    private float ascentInput; 

    public float mouseSensitivity = 100.0f;

    //Palyer boundary
    private float speed = 25.0f; //player speed
    private Vector3 boundarySize = new Vector3(60, 50, 50);
    public float ascentSpeed = 20.0f;

    //Leaning
    public float leanAngle = 15.0f; //Max angle for leaning
    public float leanSpeed = 5.0f;

    //Projectile object reference for instantiation
    public GameObject projectilePrefab;
    public Transform shootingPoint; //Shooting point reference

    private Rigidbody rigBod;

    private void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMouseInput();
        HandleLeaningInput();
        CheckBounds();
        HandleMovementInput();
    }

    private void HandleMouseInput()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        transform.Rotate(Vector3.up, horizontalRotation);

        if (Input.GetMouseButtonDown(0))
        {
            //Handle left-click logic here
            Debug.Log("Mouse 0 - Left Click");
        }

        if (Input.GetMouseButtonDown(1))
        {
            //handle rightclick logic here
            Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        }
    }

    private void HandleLeaningInput()
    {
        float currentLean = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            currentLean = leanSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            currentLean = -leanSpeed * Time.deltaTime;
        }

        //lean rotation around z-axis
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z + currentLean);
    }

    private void CheckBounds()
    {
       
    // Get the player's current position
    Vector3 currentPosition = transform.position;

    // Clamp the position within the specified boundaries
    currentPosition.x = Mathf.Clamp(currentPosition.x, -boundarySize.x, boundarySize.x);
    currentPosition.y = Mathf.Clamp(currentPosition.y, -boundarySize.y, boundarySize.y);
    currentPosition.z = Mathf.Clamp(currentPosition.z, -boundarySize.z, boundarySize.z);

    // Apply the clamped position back to the player
    transform.position = currentPosition;
    }

    private void HandleMovementInput()
    {
        //Get input from the player
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        ascentInput = 0;

        if (Input.GetKey(KeyCode.Space)) //Ascend
        {
            ascentInput = ascentSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift)) //Descend
        {
            ascentInput = -ascentSpeed;
        }

        //Calculate movement direction
        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        Vector3 ascentDirection = new Vector3(0, ascentInput, 0);

        //increase speed if the "W" key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            speed = 20.0f; //Adjust the speed
        }
        else
        {
            speed = 10.0f; //Reset speed to default
        }

        //Move the player using Rigidbody
        rigBod.velocity = moveDirection * speed + ascentDirection;
    }
}
