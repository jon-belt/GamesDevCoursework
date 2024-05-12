using UnityEngine;

public class Rifle : MonoBehaviour
{
    public float damage = 10f;
    public float range = 25f;

    public Camera cam;
    public ParticleSystem muzzleFlash;

    private Animator animator;
    void Start(){animator = GetComponent<Animator>();}
    void Update()
    {
        if(this.gameObject.activeSelf)  //only runs if gun has been picked up
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        //muzzleflash only plays once, but for some reason it plays on item switch
        muzzleFlash.Play();
        animator.SetTrigger("Shoot");
        
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            EnemyTarget target = hit.transform.GetComponent<EnemyTarget>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    public void IncDamage(float amount)
    {
        damage += amount;
    }

    public void IncRange(float amount)
    {
        range += amount;
    }
}
