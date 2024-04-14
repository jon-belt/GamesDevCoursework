using Unity.VisualScripting;
using UnityEngine;

public class IncRegenHealth : ButtonBase
{
    public PlayerHealth playerHealth;
    protected int UpgradeCount = 0;

    protected override int UpgradePriceInc => 5;
    protected override int BaseUpgradeCost => 15;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Regen Rate Increased by 0.1");
        playerHealth.IncreaseRegenRate(0.1f);

        UpgradeCount += 1;
        CurrentUpgradeCost += UpgradePriceInc;
        Debug.Log("Current Upgrade cost:" + CurrentUpgradeCost);
    }

    public override ButtonSaveData GetSaveData()
    {
        var baseData = base.GetSaveData();
        baseData.upgradeCount = this.UpgradeCount;
        UpdateButtonUI();
        return baseData;
    }

    public override void SetSaveData(ButtonSaveData saveData)
    {
        base.SetSaveData(saveData);
        this.UpgradeCount = saveData.upgradeCount;
    }    
}