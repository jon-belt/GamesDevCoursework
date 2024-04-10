using UnityEngine;

public class SpaceshipHealth : MonoBehaviour
{
    public float health;
    private float maxHealth = 1000;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            //game over
            Debug.Log("Spaceship was destroyed, GAME OVER...");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
