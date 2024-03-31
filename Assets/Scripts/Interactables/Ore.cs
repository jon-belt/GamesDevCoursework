using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour, IInteractable
{
    public PlayerBalance balance;
    public Pickaxe pickaxe;
    public GameObject pickaxeCheck;
    [SerializeField] public float durability = 10f;

    [SerializeField]
    private GameObject button;

    public void Interact()
    {
        //if pickaxe in hand, after interacting with
        if(pickaxe != null && pickaxeCheck.activeInHierarchy && pickaxe.GetComponent<Renderer>().isVisible)
        {
            pickaxe.UsePickaxe();
        }
    }

    public float ReduceDurability(float strength)
    {
        float actualDurabilityReduced = Mathf.Min(durability, strength);
        durability -= actualDurabilityReduced;

        //trigger to destroy ore after durability has been depleted
        if (durability <= 0)
        {
            DestroyAfterDelay();
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
