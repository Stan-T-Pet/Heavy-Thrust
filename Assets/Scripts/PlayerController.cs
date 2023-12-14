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
    public float xRange;
    public float ascentSpeed = 20.0f;

    // Leaning
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
        //keep player's position to stay within the specified xRange
        xRange = 53.0f;
        float xLimit = Mathf.Clamp(transform.position.x, -xRange, xRange);

        //prevent player from going below 0 on the y-axis
        float yLimit = Mathf.Max(transform.position.y, 0.0f);

        transform.position = new Vector3(xLimit, yLimit, transform.position.z);

        //keep player's position to stay within the specified xRange
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
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
