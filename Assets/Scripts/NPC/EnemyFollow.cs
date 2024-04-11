using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public EnemyAttack enemyAttack;

    private Transform playerTransform;
    private Transform spaceshipTransform;
    private NavMeshAgent agent;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spaceshipTransform = GameObject.FindGameObjectWithTag("Spaceship").transform;

        if (playerTransform == null || spaceshipTransform == null)
        {
            Debug.LogError("One or more targets are missing.");
            return;
        }

        agent = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    void Update()
    {
        //if the enemy is currently attacking
        if (enemyAttack.GetIsAttacking())
        {
            Debug.Log("Enemy is attacking");
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
            Transform target = GetClosestTarget();
            agent.SetDestination(target.position);
        }
    }

    public Transform GetClosestTarget()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        float distanceToSpaceship = Vector3.Distance(transform.position, spaceshipTransform.position);

        //return shortest distance 
        return distanceToPlayer < distanceToSpaceship ? playerTransform : spaceshipTransform;
    }
}
