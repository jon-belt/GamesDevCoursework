using UnityEngine;
using TMPro;

public abstract class ButtonBase : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public PlayerInventory playerInventory;
    public UpgradeMenuText upgradeMenuText;

    protected abstract int BaseUpgradeCost { get; }
    protected abstract int UpgradePriceInc { get; }
    protected abstract int UpgradeCount { get; }

    protected int CurrentUpgradeCost => BaseUpgradeCost + ((int)UpgradeCount * UpgradePriceInc);

    protected virtual void Start()
    {
        UpdateButtonUI();
    }

    protected virtual void PurchaseUpgrade()
    {
        if (playerInventory.balance >= CurrentUpgradeCost)
        {
            playerInventory.balance -= CurrentUpgradeCost;
            ApplyUpgrade();
            UpdateButtonUI();
        }
        else
        {
            upgradeMenuText.UpdateMessage("Not enough scrap...");
        }
    }

    protected abstract void ApplyUpgrade();

    protected void UpdateButtonUI()
    {
        buttonText.text = $"{CurrentUpgradeCost}";
    }

    public void OnUpgradeButtonClicked()
    {
        PurchaseUpgrade();
    }
}
