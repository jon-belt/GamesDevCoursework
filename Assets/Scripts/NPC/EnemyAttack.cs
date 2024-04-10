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

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spaceshipTransform = GameObject.FindGameObjectWithTag("Spaceship").transform;

        // Initialize closerTarget to a default.
        closerTarget = playerTransform; // Default to player, for example.
    }   


    void Update()
    {
        //Sets target so that enemy will only attack the target they're already locked on to
        Transform target = enemyFollow.GetClosestTarget();

        //if(isAttacking = false && attackRange > Vector3.Distance(transform.position, target.transform.position))
        if(attackRange > Vector3.Distance(transform.position, target.transform.position))
        {
            //isAttacking = true;

            if(target == GameObject.FindGameObjectWithTag("Player").transform)
            {
                health.TakeDamage(15);
            }

            if(target == GameObject.FindGameObjectWithTag("Spaceship").transform)
            {
                spaceshipHealth.TakeDamage(10);
            }

            //TO DO:
            // make attacking once per second, instead of potentially once a frame
            
            //isAttacking = false;
        }
    }
}
