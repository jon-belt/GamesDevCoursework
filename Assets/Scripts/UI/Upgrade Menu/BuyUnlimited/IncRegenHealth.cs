using Unity.VisualScripting;
using UnityEngine;

public class IncRegenHealth : ButtonBase
{
    public PlayerHealth playerHealth;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 5;
    protected override int BaseUpgradeCost => 15;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Regen Rate Increased by 0.1");
        playerHealth.IncreaseRegenRate(0.1f);

        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.healthRegenRateUpgradeCount;
    }

    public void SaveData(ref GameData data)
    {
        data.healthRegenRateUpgradeCount = this.upgradeCount;
    }
}