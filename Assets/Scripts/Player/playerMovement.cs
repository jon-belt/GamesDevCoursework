using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player
    public float jumpForce = 5f; // Jump force
    private Rigidbody rb; // Reference to the Rigidbody component
    private Vector3 movement; // The movement vector
    public Transform groundCheck; // A transform positioned at the bottom of the player used to check for ground
    public float groundDistance = 0.4f; // Distance to check for ground
    public LayerMask groundMask; // LayerMask to filter what is considered ground
    private bool isGrounded; // Is the player currently grounded
    public Transform playerCamera; // Reference to the player's camera

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        rb.constraints = RigidbodyConstraints.FreezeRotation; // Prevent rotation to avoid falling over
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Input detection
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction relative to camera orientation
        Vector3 forward = playerCamera.forward;
        Vector3 right = playerCamera.right;
        forward.y = 0; // Ignore the vertical component of the camera's forward vector
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        movement = (forward * moveZ + right * moveX).normalized;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Execute movement if grounded or allow limited control in the air
        if (isGrounded || !isGrounded) // You can adjust this condition for air control
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        // Optional: Implement logic here to minimize air control if desired
    }
}