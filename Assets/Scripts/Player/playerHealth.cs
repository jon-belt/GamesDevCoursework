using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float health;
    private float lerpTimer;
    [Header("PlayerHealth Bar")]
    public float maxHealth = 100f;
    public float regenRate = 0.1f;
    public float chipSpeed = 2f;
    public Image frontHealthbar;
    public Image backHealthbar;
    
    [Header("Damage Overlay")]
    public Image overlay;   //damage overlay
    public float duration;
    public float fadeSpeed;

    private float durationTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        regenRate = 0.2f;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //initial check: is player alive?
        if (health <= 0)
        {
            Debug.Log("Player is dead, GAME OVER...");
            return;
        }

        //base regen rate
        if (health < maxHealth)
        {
            health += regenRate * Time.deltaTime;

            // Ensure health does not exceed maxHealth
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (overlay.color.a > 0)    //checks overlay alpha channel
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                //fade blood overlay
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthbar.fillAmount;
        float fillB = backHealthbar.fillAmount;

        float hFraction = health / maxHealth;   //keeps hFrac between 0-1 for easier manipulation

        if (fillB > hFraction)
        {
            frontHealthbar.fillAmount = hFraction;
            backHealthbar.color = Color.white;

            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;

            backHealthbar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction)
        {
            backHealthbar.fillAmount = hFraction;
            backHealthbar.color = Color.green;

            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;

            frontHealthbar.fillAmount = Mathf.Lerp(fillF, hFraction, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }

    public void RestoreHealth(float heal){
        health += heal;
        lerpTimer = 0f;
    }

    public void IncreaseHealth(float num)
    {
        maxHealth += num;
    }

    public void IncreaseRegenRate(float num)
    {
        regenRate += num;
    }
}
