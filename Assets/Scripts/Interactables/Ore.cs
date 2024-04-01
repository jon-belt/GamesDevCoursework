using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour, IInteractable
{
    public PlayerBalance balance;
    [SerializeField] public float durability = 10f;
    public string InteractionPrompt => "Press E to Mine Ore";

    void Start()
    {
        balance = FindObjectOfType<PlayerBalance>();
        if(balance == null)
            Debug.LogError("PlayerBalance not found");
    }

    public void Interact()
    {
        //sets pickaxe on interact, this is because the pickaxe script needs to reference the specific ore the player is mining
        Pickaxe pickaxe = FindObjectOfType<Pickaxe>();
        
        if(pickaxe != null)
        {
            //set current ore as the target
            pickaxe.targetOre = this; //current gameobject = ore player is looking at
            pickaxe.UsePickaxe();
        }
        else
        {
            Debug.LogError("Pickaxe not found");
        }        
    }

    public float ReduceDurability(float strength)
    {
        float actualDurabilityReduced = Mathf.Min(durability, strength);
        durability -= actualDurabilityReduced;

        //trigger to destroy ore after durability has been depleted
        if (durability <= 0)
        {
            StartCoroutine(DestroyAfterDelay());
        }
        return actualDurabilityReduced;
    }

    //function to destroy after a delay, so that the mining animation looks better
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); //rough time for the animation to catch up
        Destroy(gameObject);
    }
}
