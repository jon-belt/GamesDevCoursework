using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float attackRange = 3.5f;
    private float timeSinceLastAttack = 0f;
    private float attackCooldown = 1f;
    private bool isAttacking = false;

    public PlayerHealth playerHealth;
    public SpaceshipHealth spaceshipHealth;
    public EnemyFollow enemyFollow;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        spaceshipHealth = FindObjectOfType<SpaceshipHealth>();
    }

    void Update()
    {
        if (isAttacking)
        {
            //reset attacking status after a cooldown
            if ((timeSinceLastAttack += Time.deltaTime) >= attackCooldown)
            {
                isAttacking = false;
                timeSinceLastAttack = 0;
            }
            return;
        }

        Transform target = enemyFollow.GetClosestTarget();
        if (target != null && attackRange >= Vector3.Distance(transform.position, target.position))
        {
            //attack logic
            isAttacking = true;
            timeSinceLastAttack = 0; //immediately start cooldown

            if (target.CompareTag("Player"))
            {
                playerHealth.TakeDamage(15);
                Debug.Log("Player damaged");
            }

            else if (target.CompareTag("Spaceship"))
            {
                spaceshipHealth.TakeDamage(10);
                Debug.Log("Spaceship damaged");
            }
        }
    }

    public bool GetIsAttacking()
    {
        return isAttacking;
    }

    public void SetIsAttacking(bool set)
    {
        isAttacking = set;
    }
}
