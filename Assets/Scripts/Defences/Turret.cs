using UnityEngine;

public class Turret : MonoBehaviour, IDataPersistence
{
    public Transform target;
    public Transform rotator;
    public GameObject bulletPrefab;
    public Transform firePoint;     //empty gameobject, this is where the bullet starts at
    public float range = 15;
    public float fireRate = 1;
    public float damage;        //might be upgraded in the future?  otherwise useless
    public int rangeUpgradeCount = 0;
    public int fireRateUpgradeCount = 0;

    private float fireCountdown = 0f;
    
    void Start()
    {
        //invoke repeating allows the script to be ran at an appropriate speed rather than every frame
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        range = 15;
        fireRate = 1;
    }

    void UpdateTarget()
    {
        //set variables
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");  //list of all active enemies
        float shortestDistance = Mathf.Infinity;    //infinity by default so that any enemy is the closest
        GameObject nearestEnemy = null;

        //code to find closest enemy
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            //new closest enemy found
            if(distanceToEnemy < shortestDistance)
            {
                //updates variables 
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //set target
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        //if there are no targets, dont do anything
        if (target == null)
        {
            return;
        }
        //following code only runs if there is a target, due to the previous if statement

        //move turret head:
        Vector3 dir = target.position - transform.position;     //finds direction
        Quaternion lookRotation = Quaternion.LookRotation(dir); 
        Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, Time.deltaTime*8).eulerAngles;            //turns rotation into something readable

        rotator.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);    //only turns on the y axis

        //shoot enemies
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletShoot = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        TurretBullet bullet = bulletShoot.GetComponent<TurretBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void increaseRange()
    {
        range += 10;
    }

    public void increaseFirerate()
    {
        fireRate += 1;
    }

    public void LoadData(GameData data)
    {
        this.rangeUpgradeCount = data.turretRangeUpgradeCount;
        this.fireRateUpgradeCount = data.turretFireRateUpgradeCount;

        range = 15*rangeUpgradeCount;
        fireRate = 1*fireRateUpgradeCount;
    }

    public void SaveData(ref GameData data)
    {
        data.turretRangeUpgradeCount = this.rangeUpgradeCount;
        data.turretFireRateUpgradeCount = this.fireRateUpgradeCount;
    }
}
