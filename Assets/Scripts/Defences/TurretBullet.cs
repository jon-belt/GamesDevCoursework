using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    void Update()
    {
        //destroys bullet if enemy target is no longer there
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            //logic for when the target is hit
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void HitTarget()
    {
        Destroy(gameObject); //removes bullet from scene
        EnemyTarget enemyTarget = target.GetComponent<EnemyTarget>();

        enemyTarget.TakeDamage(10); //enemy takes 10 damage
    }

}
