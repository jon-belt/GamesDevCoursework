using UnityEngine;
using System.Collections;

public class Pickaxe : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public float strength = 2f;
    public Ore targetOre;

    private Animator animator;
    private float rewardMultiplier;
    [SerializeField] private bool isUsingPickaxe = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rewardMultiplier = 1;
    }

    public void UsePickaxe()
    {
        if (isUsingPickaxe) return; //if pickaxe being used, exit

        //if the ore exists
        if (targetOre != null && targetOre.durability > 0)
        {
            isUsingPickaxe = true; //set to true so that the state is in use
            
            //play mining animation
            if (animator != null)
            {
                animator.SetTrigger("Mine");
                //play mining audio
                StartCoroutine(WaitForAnimation(animator, "UsePickaxe"));
            }
            else
            {
                //Debug.LogError("No pickaxe animation found.");
                Debug.Log("No pickaxe animation found.");
            }
        }
    }

    private IEnumerator WaitForAnimation(Animator animator, string animationName)
    {
        //wait for the animation to start playing
        yield return null; 

        //wait for the animation to finish
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && 
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        //calculate and add reward after animation is finished
        float actualDurabilityReduced = targetOre.ReduceDurability(strength);
        if (playerInventory != null)
        {
            playerInventory.AddToOre(actualDurabilityReduced+rewardMultiplier); 
        }
        else
        {
            Debug.LogError("PlayerInventory not found");
        }

        isUsingPickaxe = false;
    }

    public void IncStrength()
    {
        strength += 2;
    }

    public void IncReward()
    {
        //reward is multiplied each time, as it is only added to the durability (line 60)
        rewardMultiplier *= 2;
    }
}
