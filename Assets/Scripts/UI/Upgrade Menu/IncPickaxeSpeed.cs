using UnityEngine;

public class IncPickaxeSpeed : ButtonBase
{
    public Pickaxe pickaxe;
    public int UpgradeCount = 0;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Axe Speed Increased");

        //strength is interchangable with 'speed' as it takes the user less time to mine the
        pickaxe.IncStrength();

        UpgradeCount += UpgradeCount;
    }
}