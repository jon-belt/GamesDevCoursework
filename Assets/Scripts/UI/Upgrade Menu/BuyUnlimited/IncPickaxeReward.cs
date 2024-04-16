using UnityEngine;

public class IncPickaxeReward : ButtonBase
{
    public Pickaxe pickaxe;
    private int upgradeCount = 0;

    protected override int UpgradePriceInc => 15;
    protected override int BaseUpgradeCost => 30;
    protected override int UpgradeCount => upgradeCount;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Pickaxe Reward Increased");

        pickaxe.IncReward();

        upgradeCount += 1;
    }

    public void LoadData(GameData data)
    {
        this.upgradeCount = data.pickaxeReward;
    }

    public void SaveData(ref GameData data)
    {
        data.pickaxeReward = this.upgradeCount;
    }
}