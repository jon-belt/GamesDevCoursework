using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    private float moveSpeed; // Enemy's movement speed
    public float speedMultiplier = 0.6f; // Enemy speed as a fraction of the player's speed
    private Rigidbody enemyRb; // Enemy's Rigidbody for movement
    public playerMovement playerMovementScript; // Reference to the player's movement script

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        // Assuming the player's move speed is public and accessible
        // Adjust as necessary based on your player movement script
        moveSpeed = playerMovementScript.moveSpeed * speedMultiplier;
    }

    void Update()
    {
        // Move the enemy towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        enemyRb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }
}