using UnityEngine;
using System.Collections;

public class EnemyTarget : MonoBehaviour
{
    private Color originalColor;
    public float health = 50f;
    public Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
        originalColor = r.material.color;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        FlashRed();
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        //run death animation
    }

    public void FlashRed()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        r.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        float duration = 0.4f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            r.material.color = Color.Lerp(Color.red, originalColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        r.material.color = originalColor;
    }
}
