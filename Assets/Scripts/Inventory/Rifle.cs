using UnityEngine;

public class Rifle : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera cam;
    public ParticleSystem muzzleFlash;

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
        
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();

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
