using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public Transform playerTransform;
    public Transform spaceshipTransform;
    public PlayerHealth health;
    public EnemyFollow enemyFollow;
    public SpaceshipHealth spaceshipHealth;

    //private bool isAttacking;
    private float attackRange = 2f;
    private Transform target;
    private Transform closerTarget;
    private float timeSinceLastAttack = 0f;
    private float attackCooldown = 1f; // Cooldown period in seconds


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spaceshipTransform = GameObject.FindGameObjectWithTag("Spaceship").transform;

        // Initialize closerTarget to a default.
        closerTarget = playerTransform; // Default to player, for example.
    }   


    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;  //ensures enemy doesnt attack each frame
        Transform target = enemyFollow.GetClosestTarget();

        if (target != null && attackRange > Vector3.Distance(transform.position, target.position))
        {
            if (timeSinceLastAttack >= attackCooldown)
            {
                //reset timer
                timeSinceLastAttack = 0;

                //attack logic
                if (target == playerTransform)
                {
                    health.TakeDamage(15);
                    Debug.Log("Player damaged");
                }

                else if (target == spaceshipTransform)
                {
                    spaceshipHealth.TakeDamage(10);
                    Debug.Log("Spaceship damaged");
                }
            }
        }
    }
}
