using TMPro;
using UnityEngine;

public class BuyTurret : MonoBehaviour
{
    public TurretManager turretManager;
    public TextMeshProUGUI buttonText;
    public PlayerInventory playerInventory;
    public UpgradeMenuText upgradeMenuText;

    private int baseUpgradeCost = 200;
    private int upgradePriceInc = 200;

    private void Start()
    {
        upgradeMenuText = FindObjectOfType<UpgradeMenuText>();
        UpdateButtonUI();
    }

    private void UpdateButtonUI()
    {
        if (turretManager.turretsBought < turretManager.turrets.Length)
        {
            int currentCost = baseUpgradeCost + turretManager.turretsBought * upgradePriceInc;
            buttonText.text = $"{currentCost}";
        }
        else
        {
            buttonText.text = "Max Owned"; //max turrets bought
        }
    }

    public void OnUpgradeButtonClicked()
    {
        int currentCost = baseUpgradeCost + turretManager.turretsBought * upgradePriceInc;

        if (playerInventory.balance >= currentCost && turretManager.turretsBought < turretManager.turrets.Length)
        {
            playerInventory.balance -= currentCost;
            turretManager.UnlockTurret();
            UpdateButtonUI();
        }
        else if (turretManager.turretsBought >= turretManager.turrets.Length)
        {
            Debug.Log("All turrets have been bought.");
            upgradeMenuText.UpdateMessage("Maximum turrets purchased...");
        }
        else
        {
            upgradeMenuText.UpdateMessage("Not enough scrap...");
        }
    }
}