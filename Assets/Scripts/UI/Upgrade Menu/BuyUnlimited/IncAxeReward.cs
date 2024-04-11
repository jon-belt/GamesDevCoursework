using UnityEngine;

public class IncAxeReward : ButtonBase
{
    public Axe axe;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Axe Reward Increased");

        axe.IncReward();

        UpgradeCount += UpgradeCount;
    }
}