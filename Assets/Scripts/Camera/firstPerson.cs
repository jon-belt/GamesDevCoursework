// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class firstPerson : MonoBehaviour
// {
//     public float mouseSensitivity = 100f; // Sensitivity of the mouse movement
//     public Transform playerBody; // Reference to the player body to rotate around the Y axis
//     float xRotation = 0f; // Rotation around the X axis

//     void Start()
//     {
//         Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
//     }

//     void Update()
//     {
//         // Get mouse movement
//         float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
//         float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

//         xRotation -= mouseY; // Calculate rotation around the X axis
//         xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the rotation to prevent flipping

//         // Apply rotation around the X axis to the camera
//         transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
//         // Apply rotation around the Y axis to the player body
//         playerBody.Rotate(Vector3.up * mouseX);
//     }
// }