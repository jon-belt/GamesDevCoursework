using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Tree : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;
    [SerializeField] public float durability = 10f;
    public string InteractionPrompt => "Press E to Chop Tree";
    public LightingManager lightingManager;

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        if(playerInventory == null)
            Debug.LogError("playerInventory not found");

        lightingManager = FindObjectOfType<LightingManager>();
        if (lightingManager == null)
        {
            Debug.LogError("LightingManager not found");
        }
    }

    void Update()
    {
        //used to check the time for when new trees generate.
        //instead of having a complex script in 'TreeSpawner.cs' to control all current ore in the scene, each individual ore will destroy itself
        float currentTime = lightingManager.GetTimeOfDay();

        //as time never exactly equals 0, i need to use in between times.  This will 100% trigger, however 'currentTime = 0' will not consistently trigger
        //it would be good practice to use a bool here so that it only triggers once, however due to the content of the statement, 'Destroy()' it's only triggered once anyway
        if (currentTime >= 0 && currentTime <= 0.01)
        {
            Debug.Log("Destroyed tree");
            Destroy(gameObject);
        }
    }

    public void Interact()
    {
        //sets pickaxe on interact, this is because the pickaxe script needs to reference the specific ore the player is mining
        Axe axe = FindObjectOfType<Axe>();
        
        if(axe != null)
        {
            //set current ore as the target
            axe.targetTree = this; //current gameobject = ore player is looking at
            axe.UseAxe();
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
