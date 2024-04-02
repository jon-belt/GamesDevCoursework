using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public float strength = 2f;
    public Tree targetTree;
    private Animator animator;
    [SerializeField] private bool isUsingAxe = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void UseAxe()
    {
        if (isUsingAxe) return; //if Axe being used, exit

        //if the tree exists
        if (targetTree != null && targetTree.durability > 0)
        {
            isUsingAxe = true; //set to true so that the state is in use
            
            //play mining animation
            if (animator != null)
            {
                //need to set it up for it works for an axe
                animator.SetTrigger("Chop");
                //play mining audio
                StartCoroutine(WaitForAnimation(animator, "UseAxe"));
            }
            else
            {
                //Debug.LogError("No Axe animation found.");
                Debug.Log("No Axe animation found.");
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
        float actualDurabilityReduced;

        actualDurabilityReduced = targetTree.ReduceDurability(strength);
        
        if (playerInventory != null)
        {
            playerInventory.AddToWood(actualDurabilityReduced); 
        }
        else
        {
            Debug.LogError("Error loading balance");
        }

        isUsingAxe = false;
    }
}
