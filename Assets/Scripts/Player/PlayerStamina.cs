using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    //im not going to rename this script but this is the script just for the stamina UI, if i rename it breaks the game.. :)
    private PlayerMotor playerMotor; 
    public float stamina;
    private float lerpTimer;
    public float maxStamina = 100f;
    public float chipSpeed = 2f;
    public Image frontStaminaBar;
    public Image backStaminaBar;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMotor = FindObjectOfType<PlayerMotor>(); //find the PlayerMotor script in the scene
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMotor != null)
        {
            stamina = Mathf.Clamp(playerMotor.stamina, 0, maxStamina); //use stamina from PlayerMotor
            UpdateStaminaUI();
        }
    }

    public void UpdateStaminaUI()
    {
        float fillF = frontStaminaBar.fillAmount;
        float fillB = backStaminaBar.fillAmount;

        float sFraction = stamina / maxStamina; //keeps sFrac between 0-1 for easier manipulation

        if (fillB > sFraction)
        {
            frontStaminaBar.fillAmount = sFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backStaminaBar.fillAmount = Mathf.Lerp(fillB, sFraction, percentComplete);
        }

        if (fillF < sFraction)
        {
            backStaminaBar.fillAmount = sFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            frontStaminaBar.fillAmount = Mathf.Lerp(fillF, sFraction, percentComplete);
        }
    }

    //resets the lerp timer for smooth UI transition, called externally if needed
    public void ResetLerpTimer()
    {
        lerpTimer = 0f;
    }

    public void IncreaseStamina(int num)
    {
        maxStamina += num;
    }
}