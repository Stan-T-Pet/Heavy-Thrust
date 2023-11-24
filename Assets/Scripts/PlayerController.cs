using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Keyboard inputs
    private float horizontalInput;
    private float verticalInput;

    // Mouse controls
    public float mouseSensitivity = 100.0f;

    // Boundary specifications
    private float speed = 10.0f; // Starting speed
    public float xRange = 20.0f;

    // Projectile object reference for instantiation
    public GameObject projectilePrefab;
    private Rigidbody rigBod;

    private void Start()
    {
        // Cache the Rigidbody component for better performance
        rigBod = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMouseInput();
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
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
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

        // Calculate movement direction
        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;

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
        rigBod.velocity = moveDirection * speed;
    }
}
