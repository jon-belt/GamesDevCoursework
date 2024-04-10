using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyCompass : MonoBehaviour
{
    public CompassTrack compass;
    public HotbarManager hotbarManager;

    public TextMeshProUGUI  buttonText;
    public PlayerInventory playerInventory;

    private bool purchased;

    void Start()
    {
        purchased = false;
    }


    //similar version of the other button scripts, however everything is hard coded as the compass is only purchased once
    protected virtual void PurchaseUpgrade()
    {
        if (purchased == false){
            if (playerInventory.balance >= 100)
            {
                playerInventory.balance -= 100;
                purchased = true;
                ApplyUpgrade();     //runs logic after button has been pressed
                buttonText.text = "Purchased!";
            }
            else{Debug.Log("Not enough balance.");}
        }
        else{Debug.Log("Compass already purchased.");}
    }

    private void ApplyUpgrade()
    {
        Debug.Log("Compass Purchased");
        hotbarManager.PurchaseCompass();
    }

    public void OnUpgradeButtonClicked()
    {
        PurchaseUpgrade();
    }
}
