using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent agent;

    void Start()
    {
        //sets player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //sets navmesh
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}
