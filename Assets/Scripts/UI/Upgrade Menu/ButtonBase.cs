using UnityEngine;
using TMPro;

public abstract class ButtonBase : MonoBehaviour
{
    public TextMeshProUGUI  buttonText;
    public PlayerInventory playerInventory;

    protected int CurrentUpgradeCost;
    protected abstract int BaseUpgradeCost { get; }
    protected abstract int UpgradePriceInc {get; }

    protected virtual void Start()
    {
        CurrentUpgradeCost = BaseUpgradeCost;
        UpdateButtonUI();
    }


    //method used by any child of this class to purchase using balance
    protected virtual void PurchaseUpgrade()
    {
        if (playerInventory.balance >= CurrentUpgradeCost)
        {
            playerInventory.balance -= CurrentUpgradeCost;
            ApplyUpgrade();     //runs logic after button has been pressed

            CurrentUpgradeCost += UpgradePriceInc;
            UpdateButtonUI();   //changes button to read a higher number
        }
        else
        {
            Debug.Log("Not enough balance.");
        }
    }

    protected abstract void ApplyUpgrade();

    //method used to change the text in the button, so that buying gets priogressivly more expensive        
    protected void UpdateButtonUI()
    {
        buttonText.text = $"{CurrentUpgradeCost}";
    }

    //links the onclick event to the button
    public void OnUpgradeButtonClicked()
    {
        PurchaseUpgrade();
    }
}
