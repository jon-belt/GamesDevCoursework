using UnityEngine;
using TMPro;

public class BuyTimer : MonoBehaviour
{
    public TimerLogic timerLogic;

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
            if (playerInventory.balance >= 50)
            {
                playerInventory.balance -= 50;
                purchased = true;
                ApplyUpgrade();     //runs logic after button has been pressed
                buttonText.text = "Purchased!";
            }
            else{Debug.Log("Not enough balance.");}
        }
        else{Debug.Log("Timer already purchased.");}
    }

    private void ApplyUpgrade()
    {
        Debug.Log("Timer Purchased");
        timerLogic.Purchase();
    }

    public void OnUpgradeButtonClicked()
    {
        PurchaseUpgrade();
    }
}
