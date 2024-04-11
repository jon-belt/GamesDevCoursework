using UnityEngine;

public class IncAxeSpeed : ButtonBase
{
    public Axe axe;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 5;
    protected override int BaseUpgradeCost => 15;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Axe Speed Increased");

        //strength is interchangable with 'speed' as it takes the user less time to mine the ore
        axe.IncStrength();

        UpgradeCount += UpgradeCount;
    }
}