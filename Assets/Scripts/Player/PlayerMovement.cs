// using UnityEngine;

// public class playerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f; 
//     public float jumpForce = 5f; 
//     public Transform groundCheck; 
//     public float groundDistance = 0.4f; 
//     public LayerMask groundMask; 
//     public Transform playerCamera; 
//     public bool canMove = true;

//     private Rigidbody rb; 
//     private Vector3 movement; 
//     private bool isGrounded; 

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
//         rb.constraints = RigidbodyConstraints.FreezeRotation; // Prevent rotation to avoid falling over
//     }

//     void Update()
//     {
//         if (!canMove) return;   //skips all code if the player can't move

//         //check if the player is grounded
//         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

//         //input detection
//         float moveX = Input.GetAxis("Horizontal");
//         float moveZ = Input.GetAxis("Vertical");

//         //calculate movement direction relative to camera orientation
//         Vector3 forward = playerCamera.forward;
//         Vector3 right = playerCamera.right;
//         forward.y = 0;
//         right.y = 0;
//         forward.Normalize();
//         right.Normalize();

//         movement = (forward * moveZ + right * moveX).normalized;

//         if (Input.GetButtonDown("Jump") && isGrounded)
//         {
//             rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//         }
//     }

//     void FixedUpdate()
//     {
//         //execute movement if grounded or allow limited control in the air
//         if (isGrounded || !isGrounded)
//         {
//             rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
//         }
//     }
// }