using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private Transform playerTransform;
    private Transform spaceshipTransform;
    private NavMeshAgent agent;

    void Start()
    {
        //sets player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //sets spaceship
        spaceshipTransform = GameObject.FindGameObjectWithTag("Spaceship").transform;

        if (playerTransform == null || spaceshipTransform == null)
        {
            Debug.LogError("One or more targets are missing.");
            return;
        }

        //sets navmesh
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //finds closer target
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        float distanceToSpaceship = Vector3.Distance(transform.position, spaceshipTransform.position);

        //distance finding algorithm: 50/50 with a bias towards the player
        Transform closerTarget;

        //logic to attack player, if player is close to the ship, possibly defending it
        //check if the enemy is within 2m of the spaceship
        if (distanceToSpaceship <= 2) {
            if (distanceToPlayer < distanceToSpaceship * 1.5)
            {
                closerTarget = playerTransform;
            }
            else
            {
                closerTarget = spaceshipTransform;
            }
        }

        //chose closer target if alien is not currently attacking the ship
        else
        {
            if (distanceToPlayer < distanceToSpaceship)
            {
                closerTarget = playerTransform;
            }
            else {
                closerTarget = spaceshipTransform;
            }
        }

        //sets route
        agent.SetDestination(closerTarget.position);
    }
}
