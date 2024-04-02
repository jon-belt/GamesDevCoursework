using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapConverter : MonoBehaviour, IInteractable
{
    public PlayerInventory playerInventory;

    //pdates the interaction prompt based on player's resource count
    public string InteractionPrompt
    {
        get
        {
            //if the player has any resources to convert
            if (playerInventory.ore > 0 || playerInventory.wood > 0)
            {
                return "Press E to Convert Resources to Scrap";
            }
            else
            {
                return "No Resources to Convert";
            }
        }
    }

    //upon interact, all resources are converted
    //there's no crafting system, no need to overcomplicate this so no UI is needed
    public void Interact()
    {
        float ore = playerInventory.ore;
        float wood = playerInventory.wood;

        float balAdded;

        if(ore >= 1)    //if the player has ore
        {
            balAdded = ore*2;   //ore is more valuable than wood, so a 2x multiplier is applied
            playerInventory.AddToBalance(balAdded); //adds to balance
            playerInventory.RemoveFromOre(ore);    //minus ore from player inventory
            //play sound?
        }

        if(ore >= 1)    //if the player has ore
        {
            balAdded = wood;   //wood is less valuable than ore, so no multiplier
            playerInventory.AddToBalance(balAdded); //adds to balance
            playerInventory.RemoveFromWood(wood);   //minus wood from player inventory
            //play sound?
        }
    }
}
