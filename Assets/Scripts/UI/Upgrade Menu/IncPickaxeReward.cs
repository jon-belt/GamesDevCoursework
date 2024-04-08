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

        UpgradeCount += UpgradeCount;
    }
}