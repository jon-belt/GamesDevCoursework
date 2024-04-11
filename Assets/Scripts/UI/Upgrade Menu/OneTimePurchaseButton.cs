using UnityEngine;
using TMPro;

public abstract class OneTimePurchaseButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public PlayerInventory playerInventory;
    public UpgradeMenuText upgradeMenuText;

    protected bool purchased = false;
    protected abstract int ItemCost { get; }
    protected abstract string SuccessText { get; }

    protected virtual void Start()
    {
        upgradeMenuText = FindObjectOfType<UpgradeMenuText>();
        UpdateButtonUI();
    }

    protected void PurchaseUpgrade()
    {
        if (!purchased)
        {
            if (playerInventory.balance >= ItemCost)
            {
                playerInventory.balance -= ItemCost;
                purchased = true;
                ApplyUpgrade();
                buttonText.text = SuccessText;
            }
            else
            {
                upgradeMenuText.UpdateMessage("Not enough scrap...");
            }
        }
        else
        {
            //weird error where it says "Buy [item]" instead of just the item itself - this is a silly workaround

            string objName = gameObject.name;
            objName = objName.Remove(0,4);
            upgradeMenuText.UpdateMessage($"{objName} already purchased...");
        }
    }

    protected abstract void ApplyUpgrade();

    protected void UpdateButtonUI()
    {
        if (!purchased)
        {
            buttonText.text = $"{ItemCost}";
        }
        else
        {
            buttonText.text = SuccessText;
        }
    }

    public void OnUpgradeButtonClicked()
    {
        PurchaseUpgrade();
    }
}
