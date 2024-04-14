using UnityEngine;
using TMPro;

public abstract class ButtonBase : MonoBehaviour
{
    public TextMeshProUGUI  buttonText;
    public PlayerInventory playerInventory;
    public UpgradeMenuText upgradeMenuText;

    public int CurrentUpgradeCost;
    protected abstract int BaseUpgradeCost { get; }
    protected abstract int UpgradePriceInc {get; }
    // public int UpgradeCount { get; protected set; }

    protected virtual void Start()
    {
        CurrentUpgradeCost = BaseUpgradeCost;
        upgradeMenuText = FindObjectOfType<UpgradeMenuText>();
        UpdateButtonUI();
    }

    public int CalculatePrice(int UpgradeCount)
    {
        return BaseUpgradeCost + (UpgradePriceInc * UpgradeCount);
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
            upgradeMenuText.UpdateMessage("Not enough scrap...");
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

    // Method to create a data object that contains all necessary information to save the state of the button
    public virtual ButtonSaveData GetSaveData()
    {
        return new ButtonSaveData
        {
            buttonType = GetType().ToString(), // Get the specific type of button to enable correct loading
            currentUpgradeCost = CurrentUpgradeCost
        };
    }

    // Method to apply saved data to the button
    public virtual void SetSaveData(ButtonSaveData saveData)
    {
        CurrentUpgradeCost = saveData.currentUpgradeCost;
        UpdateButtonUI();
    }
}
