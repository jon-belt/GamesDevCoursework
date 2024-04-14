using UnityEngine;

public class IncPickaxeReward : ButtonBase
{
    public Pickaxe pickaxe;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 15;
    protected override int BaseUpgradeCost => 30;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Pickaxe Reward Increased");

        pickaxe.IncReward();

        UpgradeCount += 1;
    }
    
    public override ButtonSaveData GetSaveData()
    {
        var baseData = base.GetSaveData();
        baseData.upgradeCount = this.UpgradeCount;
        return baseData;
    }

    public override void SetSaveData(ButtonSaveData saveData)
    {
        base.SetSaveData(saveData);
        this.UpgradeCount = saveData.upgradeCount;
    }    
}