using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncRifleDamage : ButtonBase
{
    public int UpgradeCount = 0;
    public Rifle rifle;

    protected override int UpgradePriceInc => 10;
    protected override int BaseUpgradeCost => 20;

    protected override void ApplyUpgrade()
    {
        Debug.Log("Gun Damaged Increased");

        rifle.IncDamage(5);

        UpgradeCount += UpgradeCount;
    }
}
