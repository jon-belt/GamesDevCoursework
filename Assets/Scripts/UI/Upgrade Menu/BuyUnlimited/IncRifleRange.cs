using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncRifleRange : ButtonBase
{
    public int UpgradeCount = 0;
    public Rifle rifle;

    protected override int UpgradePriceInc => 15;
    protected override int BaseUpgradeCost => 30;
    
    protected override void ApplyUpgrade()
    {
        Debug.Log("Gun Range Increased");

        rifle.IncRange(10);
        
        UpgradeCount += UpgradeCount;
    }
}
