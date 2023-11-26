using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Keyboard inputs
    private float horizontalInput; //Input for horizontal movement (x-axis)
    private float verticalInput; //Input for vertical movement
    private float ascentInput; // Input for vertical movement (y-axis)

    // Mouse controls
    public float mouseSensitivity = 100.0f;

    // Boundary specifications
    private float speed = 10.0f; // Starting speed
    public float xRange = 20.0f;
    public float ascentSpeed = 5.0f; // Speed for vertical movement

    // Leaning
    public float leanAngle = 15.0f; // Maximum angle for leaning
    public float leanSpeed = 5.0f; // Speed of leaning

    // Projectile object reference for instantiation
    public GameObject projectilePrefab;
    public Transform shootingPoint; // Shooting point reference

    private Rigidbody rigBod;

    private void Start()
    {
        // Cache the Rigidbody component for better performance
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
            // Handle left-click (reload) logic here
            Debug.Log("Mouse 0 - Left Click");
        }

        if (Input.GetMouseButtonDown(1))
        {
            // Handle right-click (shoot) logic here
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

        // Apply lean rotation around z-axis
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z + currentLean);
    }

    private void CheckBounds()
    {
        // Clamp the player's position to stay within the specified xRange
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void HandleMovementInput()
    {
        // Get input from the player
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        ascentInput = 0;

        if (Input.GetKey(KeyCode.Space)) // Ascend
        {
            ascentInput = ascentSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift)) // Descend
        {
            ascentInput = -ascentSpeed;
        }

        // Calculate movement direction
        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        Vector3 ascentDirection = new Vector3(0, ascentInput, 0);

        // Increase speed if the "W" key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            speed = 20.0f; // Adjust the speed as needed
        }
        else
        {
            speed = 10.0f; // Reset speed to the default value
        }

        // Move the player using Rigidbody
        rigBod.velocity = moveDirection * speed + ascentDirection;
    }
}
